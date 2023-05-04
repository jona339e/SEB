using SEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.Interfaces
{
    internal interface IGetCategories
    {
        List<Categories> GetCategories();
    }
}
