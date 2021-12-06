using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrestructure.Data
{
    public class ToDoDBContext : DbContext, IUnitOfWork
    {
        public ToDoDBContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {
            
        }
        public DbSet <ToDo> toDos { get; set; }
    }
}
