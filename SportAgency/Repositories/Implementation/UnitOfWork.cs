﻿using SportAgency.Repositories.Interfaces;

namespace SportAgency.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
