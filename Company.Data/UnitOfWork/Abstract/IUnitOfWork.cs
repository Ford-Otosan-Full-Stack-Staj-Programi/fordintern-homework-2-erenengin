using Company.Data;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Account> genericRepository { get; }
    IGenericRepository<Person> PersonRepository { get; }
    void Complete();
}