using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Rezor.Services
{
    interface ICommon
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity, int id) where T : class;
        void Delete<T>(T entity) where T : class;
        
    }
}
