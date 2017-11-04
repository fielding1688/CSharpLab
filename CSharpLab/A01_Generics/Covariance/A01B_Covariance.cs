using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab.A01_Generics.Covariance
{
    public interface ILevelGet<out T>
    {
        T Get(int id);
    }

    public interface ILevelAdd<in T>
    {
        void Add(T level);
    }
    public class LevelPool<T> : ILevelGet<T>, ILevelAdd<T> 
        where T : class, ILevel,new()

    {
        private List<T> Pool { get; }
        public LevelPool()
        {
            this.Pool = new List<T>();
        }
        public void Add(T level)
        {
            this.Pool.Add(level);
        }

        public T Get(int id)
        {
            var a = this.Pool.SingleOrDefault(x => x.LevelId == id) ?? new T();
            return a;
        }
    }

    public class A01B_Covariance
    {
        private LevelPool<Level2> Level2Pools { get; set; }
        public A01B_Covariance()
        {
            this.Level2Pools = new LevelPool<Level2>();
        }

        public void test()
        {
            //out 共變性 Covariant
            //基底取代衍生
            GetLevel1(this.Level2Pools);
            GetLevel2(this.Level2Pools);
            //GetLevel3(this.Level2Pools);編譯失敗

            //in 逆變性 Contravariant
            //衍生取代基底
            //AddLevel1(this.Level2Pools);編譯失敗
            AddLevel2(this.Level2Pools);
            AddLevel3(this.Level2Pools);
        }
        


        private void AddLevel3(ILevelAdd<Level3> repository)
        {
            repository.Add(new Level3 { LevelId = 301, Name = "Level3" });
        }

        private void AddLevel2(ILevelAdd<Level2> repository)
        {
            repository.Add(new Level2 { LevelId = 201, Name = "Level2" });
        }

        private void AddLevel1(ILevelAdd<Level1> repository)
        {
            repository.Add(new Level1 { LevelId = 101, Name = "Level1" });
        }

        private void GetLevel1(ILevelGet<Level1> repository)
        {
            var Level1 = repository.Get(301);
            Console.WriteLine(Level1.LevelId);
        }

        private void GetLevel2(ILevelGet<Level2> repository)
        {
            var Level1 = repository.Get(301);
            Console.WriteLine(Level1.LevelId);
        }

        private void GetLevel3(ILevelGet<Level3> repository)
        {
            var Level1 = repository.Get(301);
            Console.WriteLine(Level1.LevelId);
        }
    }
}
