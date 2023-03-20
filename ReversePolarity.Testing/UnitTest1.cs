using Jint;
using Jint.Native;

namespace ReversePolarity.Testing;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var engine = new Engine();
        engine.Execute("function arduino() { return 11; }");
        Assert.AreEqual(engine.Invoke("arduino"), 11);
    }

    [TestMethod]
    public void Classes()
    {
        var engine = new Engine(options =>
        {
            options.EnableModules(@"C:\Scripts");
            options.AllowClr();
        });
        
        engine.Execute(@"
        class Test{ 
            constructor() {
                 this.myProperty = null;
            }
            SayHi() {
                return 'hi';  
            } 
        }");
        dynamic a = engine.Evaluate("({ SayHi: (d) => { return d.SayHi(); }, aida: 11 })").ToObject();
        Assert.AreEqual(a.SayHi(engine, new JsValue[] { new Test() }), "hi");
    }

    public class Test
    {
        public dynamic myProperty;

        dynamic SayHi()
        {
            return "hi";
        }
    }
}