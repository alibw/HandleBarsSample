using HandlebarsDotNet;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace HandleBarSample;

[TestFixture]
public class Test
{
    [Test]
    public void HandlebarAndSbEquality()
    {
        var hosts = """
                    localhost:5001;vhostport=8443;requestheaderx-forwarded=true;enablewebsocket=true;wspaths=/ws1,/ws2;preservehost=true;timeout=1800
                    localhost:5002
                    test.example.com:6000
                    """;

        var template = """
                       <VirtualHost *:{{VhostPort}}>
                       ServerName {{Domain}}
                       </VirtualHost>
                       """;
        
        var cfg = new
        {
            VHostPort = "5002",
            Domain = "localhost"
        };
        var gen = new Generator();
        var resultWithSb = gen.GenerateWithSb(cfg);

        var compiledHandleBar = Handlebars.Compile(template);
        var resultWithHandleBar = compiledHandleBar(cfg);
        
        ClassicAssert.AreEqual(resultWithHandleBar, resultWithSb);
    }
}