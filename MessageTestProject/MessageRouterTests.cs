using Allure.Xunit.Attributes;
using MessageTestProject.Messaging;
using MessageTestProject.Model;
using Xunit;

namespace MessageTestProject
{
    [AllureSuite("Message Routing Test")]
    public class MessageRouterTests
    {
        [AllureXunit]
        public void ShouldEnrichByTickerTest()
        {
            Message m1 = new()
            {
                ID = 1,
                Date = DateTime.Now,
                Ticker = "AAPL",
                Price = 1234.56M,
                Qty = 7890
            };

            Sender.Send(m1);

            Message m2 = Receiver.Receive();
            Assert.Equal(m1.ID, m2.ID);
            Assert.Equal(m1.Date, m2.Date);
            Assert.Equal(m1.Ticker, m2.Ticker);
            Assert.Equal(m1.Price, m2.Price);
            Assert.Equal(m1.Qty, m2.Qty);
        }
    }
}