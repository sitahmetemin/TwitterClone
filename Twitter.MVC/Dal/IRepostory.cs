using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.MVC.Entities;

namespace Twitter.MVC.Dal
{
    public interface IRepostory <T>
    {

        List<T> GetAll();
        T Get(int Id);
        void Add(T Entitiy);
        void Update(T Entitiy);
        void Delete(T Entitiy);
    }
}
