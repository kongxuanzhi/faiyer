# DesignPattern
//设计模式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    //抽象类相当于接口，
    //抽象方法没有实现体，子类必须实现，
    //虚方法有实现体，子类可以选择性重写
    public abstract class Operator
    {
        public int NumberA { get; set; }
        public int NumberB { get; set; }

        public abstract double GetResult();  //有虚方法就一定定义为抽象类
        
    }
    public class operatorAdd : Operator
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    public class operatorSub : Operator
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
    public class operatorMul : Operator
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
    public class operatorDiv : Operator
    {
        public override double GetResult()
        {
            return NumberA/NumberB;
        }
    }
    //静态工厂类，由客户端输入决定实现那个子类
    class operatorFactory
    {
        public static Operator createOperator(string type)
        {
            Operator op = null;
            switch (type)
            {
                case "+":
                    op=  new operatorAdd();
                    break;
                case "-":
                    op =  new operatorSub();
                    break;
                case "*":
                    op =  new operatorMul();
                    break;
                case "/":
                    op =  new operatorDiv();
                    break;
            }
            return op;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Operator operat = operatorFactory.createOperator("*");
            operat.NumberA = 2;
            operat.NumberB = 4;
            double result = operat.GetResult();
            Console.WriteLine(result);
        }
    }
}
