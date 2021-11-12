using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyDB.DbOperation
{
    public class StudentRepository
    {
        public int AddStudent(RegStudent model)
        {
            using (var context = new RegisterDatabaseEntities2())
            {
                
                StudentReg std = new StudentReg()
                {
                 FirstName = model.FirstName,
                 LastName = model.LastName,
                 Email = model.Email,
                 Address = model.Address,
                 Country = model.Country,
                 ZipCode = model.ZipCode,
                 Gender = model.Gender,
                 BirthDate = model.BirthDate,

                };
                context.StudentReg.Add(std);
                context.SaveChanges();
                return std.Id;

            }
        }
        public List<RegStudent> getallStudents()
        {
            using (var context = new RegisterDatabaseEntities2())
            {
                var Result = context.StudentReg
                    .Select(x=>new RegStudent()
                    {
                        Id=x.Id,
                        FirstName=x.FirstName,
                        LastName   =x.LastName,
                        Email=x.Email,
                        Address=x.Address,
                        Country=x.Country,
                        ZipCode=x.ZipCode,
                        Gender = x.Gender,
                        BirthDate=x.BirthDate,
                    }).ToList();
                return Result;

            }
        }
        public RegStudent getStudent(int Id)
        {
            using (var context = new RegisterDatabaseEntities2())
            {
                var Result = context.StudentReg
                    .Where(x=>x.Id==Id)
                    .Select(x => new RegStudent()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Address = x.Address,
                        Country = x.Country,
                        ZipCode = x.ZipCode,
                        Gender = x.Gender,
                        BirthDate = x.BirthDate,
                    }).FirstOrDefault();
                return Result;

            }
        }

        public bool UpdateStudent(int Id, RegStudent model)
        {
            using (var context = new RegisterDatabaseEntities2())
            {
                var Std1= context.StudentReg.FirstOrDefault(x=>x.Id==Id);
                if(Std1!=null)
                {
                    Std1.FirstName = model.FirstName;
                    Std1.LastName = model.LastName;
                    Std1.Email=model.Email;
                    Std1.Address = model.Address;
                    Std1.Country = model.Country;
                    Std1.ZipCode = model.ZipCode;
                    Std1.Gender = model.Gender;
                    Std1.BirthDate = model.BirthDate;

                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteStudent(int Id)
        {
            using (var context = new RegisterDatabaseEntities2())
            {
                var std2 = context.StudentReg.FirstOrDefault(x => x.Id == Id);
                if(std2!=null)
                {
                    context.StudentReg.Remove(std2);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
