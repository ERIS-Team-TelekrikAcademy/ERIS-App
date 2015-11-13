﻿namespace ErisSystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using ErisSystem.Services.Contracts;
    using Data;
    using Data.Repositories;

    public class ClientsServices : IClientServices
    {
        IRepository<Client> clients;

        public ClientsServices()
        {
            this.clients = new EfGenericRepository<Client>(new ErisSystemContext());
        }

        public ClientsServices(IRepository<Client> clients)
        {
            this.clients = clients;
        }

        public int Add(string nickName, string password, DateTime registrationDate)
        {
            var isValidUserName = Validator.ValidateStringLenght(3, 20, nickName);

            if (!isValidUserName)
            {
                throw new ArgumentOutOfRangeException("Invalid user name length");
            }

            var client = new Client();
            client.Nickname = nickName;
            client.Password = password;
            client.RegistrationDate = registrationDate;

            this.clients.Add(client);

            return this.clients.SaveChanges();
        }

        public void Delete(Client client)
        {
            this.clients.Delete(client);
            this.clients.SaveChanges();
        }

        public IQueryable<Client> GetAll()
        {
            var result = this.clients.All();

            return result;
        }

        public Client GetById(int id)
        {
            var result = this.clients.GetById(id);

            return result;
        }
    }
}
