using Allure.Xunit.Attributes;
using MessageTestProject.Messaging;
using MessageTestProject.Model;
using Xunit;
using Xunit.Abstractions;

namespace MessageTestProject
{
    [AllureSuite("Message Routing Test (RabbitMQ)")]
    public class MessageRouterTests
    {
        private readonly ITestOutputHelper outputHelper;

        public MessageRouterTests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

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

            Sender.Send(m1, outputHelper);

            Message m2 = Receiver.Receive(outputHelper);
            Assert.Equal(m1.ID, m2.ID);
            Assert.Equal(m1.Date, m2.Date);
            Assert.Equal(m1.Ticker, m2.Ticker);
            Assert.Equal(m1.Price, m2.Price);
            Assert.Equal(m1.Qty, m2.Qty);
            Assert.Equal("US0378331005", m2.ISIN);
            Assert.Equal("Apple Inc", m2.CompanyName);
        }

        [AllureXunit]
        public void ShouldEnrichByISINTest()
        {
            Message m1 = new()
            {
                ID = 2,
                Date = DateTime.Now,
                ISIN = "US5949181045",
                Price = 1.23M,
                Qty = 45
            };

            Sender.Send(m1, outputHelper);

            Message m2 = Receiver.Receive(outputHelper);
            Assert.Equal(m1.ID, m2.ID);
            Assert.Equal(m1.Date, m2.Date);
            Assert.Equal(m1.ISIN, m2.ISIN);
            Assert.Equal(m1.Price, m2.Price);
            Assert.Equal(m1.Qty, m2.Qty);
            Assert.Equal("MSFT", m2.Ticker);
            Assert.Equal("Microsoft Corp", m2.CompanyName);
        }

        [AllureXunit]
        public void ShouldEnrichByCompanyNameTest()
        {
            Message m1 = new()
            {
                ID = 3,
                Date = DateTime.Now,
                CompanyName = "International Business Machines Corp",
                Price = 9.99M,
                Qty = 11
            };

            Sender.Send(m1, outputHelper);

            Message m2 = Receiver.Receive(outputHelper);
            Assert.Equal(m1.ID, m2.ID);
            Assert.Equal(m1.Date, m2.Date);
            Assert.Equal(m1.CompanyName, m2.CompanyName);
            Assert.Equal(m1.Price, m2.Price);
            Assert.Equal(m1.Qty, m2.Qty);
            Assert.Equal("IBM", m2.Ticker);
            Assert.Equal("US4592001014", m2.ISIN);
        }

        [AllureXunit]
        public void ShouldEnrichByRandomTickerTest()
        {
            Message m1 = new()
            {
                ID = 4,
                Date = DateTime.Now,
                Ticker = "RANDOM",
                Price = 9M,
                Qty = 10
            };

            Sender.Send(m1, outputHelper);

            Message m2 = Receiver.Receive(outputHelper);
            Assert.Equal(m1.ID, m2.ID);
            Assert.Equal(m1.Date, m2.Date);
            Assert.Equal(m1.Ticker, m2.Ticker);
            Assert.Equal(m1.Price, m2.Price);
            Assert.Equal(m1.Qty, m2.Qty);
            Assert.Equal("", m2.ISIN);
            Assert.Equal("", m2.CompanyName);
        }
    }
}