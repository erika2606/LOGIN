﻿using Microsoft.EntityFrameworkCore;
using SIBKMNetErika.Context;
using SIBKMNetErika.Handler;
using SIBKMNetErika.Models;
using SIBKMNetErika.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }


        public ResponseLogin Login(Login login)
        {
            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x => x.User.Employee.Email.Equals(login.Email));
            var verify = Hashing.ValidatePassword(login.Password, data.User.Password);
            if(verify)
            {
                var response = new ResponseLogin()
                {
                    Id = data.User.Employee.Id,
                    FullName = data.User.Employee.FullName,
                    Email = data.User.Employee.Email,
                    Role = data.Role.Name
                };
                return response;
            }
            return null;
        }

        //register
        public int Register(Register register)
        {
            Employee employee = new Employee()
            {
                FullName = register.FullName,
                Email = register.Email
            };
            myContext.Employees.Add(employee);
            var resultEmployee = myContext.SaveChanges();
            if(resultEmployee > 0)
            {
                int id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Users.Add(user);
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    UserRole userRole = new UserRole()
                    {
                        UserId = id,
                        RoleId = register.RoleId
                    };
                    myContext.UserRoles.Add(userRole);
                    var resultUserRole = myContext.SaveChanges();
                    if (resultUserRole > 0)
                        return resultUserRole;
                    myContext.Users.Remove(user);
                    myContext.SaveChanges();
                    myContext.Employees.Remove(employee);
                    myContext.SaveChanges();
                    return 0;
                }
                myContext.Employees.Remove(employee);
                myContext.SaveChanges();
                return 0;
                
            }
            return 0;
        }
        

    }
}
