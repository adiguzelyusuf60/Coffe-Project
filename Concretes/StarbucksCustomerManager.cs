﻿using CoffeeProject.Abstracts;
using CoffeeProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProject.Concretes
{
    public class StarbucksCustomerManager : BaseCustomerManager
    {

        ICustomerCheckService _customerCheckService;

        public StarbucksCustomerManager(ICustomerCheckService customerCheckService)
        {
            _customerCheckService = customerCheckService;
        }
        public override void Save(Customer customer)
        {

            if (_customerCheckService.CheckIfRealPerson(customer))
            {
                base.Save(customer);
            }
            else
            {
                throw new Exception("Not a valid person");
            }

        }
    }
}
