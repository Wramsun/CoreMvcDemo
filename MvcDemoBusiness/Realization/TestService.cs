using MvcDemoBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcDemoBusiness.Realization
{
    public class TestService : ITestService
    {
        public string GetTestString(TestRequest testStr)
        {
            return testStr.Name;
        }
    }
}
