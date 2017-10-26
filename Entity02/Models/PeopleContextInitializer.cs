using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entity02.Models
{
    public class PeopleContextInitializer : DropCreateDatabaseAlways<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            Company Company01 = new Company { CompanyName = "IBM", CompanyLocation = "USA" };
            Company Company02 = new Company { CompanyName = "Google", CompanyLocation = "USA" };
            Company Company03 = new Company { CompanyName = "Mercedes", CompanyLocation = "Germany" };
            Company Company04 = new Company { CompanyName = "Trumpeter", CompanyLocation = "China" };


            context.Companyes.Add(Company01);
            context.Companyes.Add(Company02);
            context.Companyes.Add(Company03);
            context.Companyes.Add(Company04);


            Worker w1 = new Worker { Name = "Max", Surname = "Khudoley", Age = 27, Company = Company01 };
            Worker w2 = new Worker { Name = "Tim", Surname = "Mudriy", Age = 29, Company = Company02 };
            Worker w3 = new Worker { Name = "Taras", Surname = "Seredyuk", Age = 50, Company = Company03 };
            Worker w4 = new Worker { Name = "Mark", Surname = "Cukerberg", Age = 39, Company = Company04 };
            Worker w5 = new Worker { Name = "Tom", Surname = "Cruise", Age = 49, Company = Company03 };
            Worker w6 = new Worker { Name = "Adam", Surname = "Wilder", Age = 42, Company = Company02 };
            Worker w7 = new Worker { Name = "Tony", Surname = "Scott", Age = 50, Company = Company01 };
            Worker w8 = new Worker { Name = "Conor", Surname = "McCregor", Age = 31, Company = Company03 };
            Worker w9 = new Worker { Name = "Dana", Surname = "White", Age = 52, Company = Company04 };

            context.Workers.Add(w1);
            context.Workers.Add(w2);
            context.Workers.Add(w3);
            context.Workers.Add(w4);
            context.Workers.Add(w5);
            context.Workers.Add(w6);
            context.Workers.Add(w7);
            context.Workers.Add(w8);
            context.Workers.Add(w9);

            Hobby h1 = new Hobby { HobbyName = "Scale Modeling", Workers = new List<Worker> { w1, w2, w5 } };
            Hobby h2 = new Hobby { HobbyName = "Philately", Workers = new List<Worker> { w3, w4, w8 } };
            Hobby h3 = new Hobby { HobbyName = "Numizmatics", Workers = new List<Worker> { w6, w7, w5 } };
            Hobby h4 = new Hobby { HobbyName = "Fishing", Workers = new List<Worker> { w9, w2, w5 } };

            context.Hobbyes.Add(h1);
            context.Hobbyes.Add(h2);
            context.Hobbyes.Add(h3);
            context.Hobbyes.Add(h4);

            context.SaveChanges();
        }
    }
}