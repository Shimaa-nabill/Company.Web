using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Contexts.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Address).IsRequired();

        }
    }
}
