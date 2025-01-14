﻿using CoffeeProject.Abstracts;
using CoffeeProject.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;
using static MernisServiceReference.KPSPublicSoapClient;

namespace CoffeeProject.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
            var result = client.TCKimlikNoDogrulaAsync(long.Parse(customer.NationallyId), customer.FirstName.ToUpper(), customer.LastName.ToUpper(), customer.DateOfBirth.Year).GetAwaiter().GetResult();
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}