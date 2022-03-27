using System;
using System.Collections.Generic;

namespace IntroSQL
{
    public interface IDepartmentRepository
    {
        IEnumerable<Product> GetAllDepartments(); //Stubbed out method
    }
}

