﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T>
    {
        List<T> GetAll();
        List<T> GetAllById(int id);
    }
}
