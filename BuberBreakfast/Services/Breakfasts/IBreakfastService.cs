using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts
{
    public interface IBreakfastService
    {

        void CreateBreakfast(Breakfast breakfast);
        Breakfast GetBreakfast(Guid id);
    }
}