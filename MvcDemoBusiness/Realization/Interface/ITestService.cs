using MvcDemoBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcDemoBusiness.Realization
{
    public interface ITestService
    {
        string GetTestString(TestRequest testStr);
    }
}
