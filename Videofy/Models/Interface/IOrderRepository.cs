﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videofy.Models.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
