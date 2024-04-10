using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Domain.Entities
{
    public sealed record Person(string Name, DateTime DateOfBirth)
    {
    }
}
