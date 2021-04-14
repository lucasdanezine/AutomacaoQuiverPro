using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;

namespace QuiverPro
{
    class NavegaMenu
    {
      
        public IWebDriver NavegaInicio(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[3]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaVendas(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[4]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaRenovacao(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[5]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaOperacional(IWebDriver navega)
        {
            IWebDriver driver = navega;
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[6]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaAreaSeguradoras(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[7]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaComissoesPremios(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[8]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaProdutores(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[9]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaSinistros(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[10]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaFluxoCaixa(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[11]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaDashBoard(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[12]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaEstruturaHierarq(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[13]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaAnaliseEstatistica(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[14]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaPosVendas(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[15]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaInterfaces(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[16]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaCoCorretagem(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[17]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaIntegracoes(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[18]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaDifContabil(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[19]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaMultProdutos(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[20]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaContratos(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[21]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaPortal(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[22]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver NavegaServExterno(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.XPath("//*[@id=\"MenuTopo\"]/header/div[1]/div[1]/div[1]/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navSide\"]/div[23]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            return driver;
        }

        public IWebDriver BtnGravar(IWebDriver navega)
        {
            IWebDriver driver = navega;
            driver.FindElement(By.Id("BtGravar")).Click();

            try
            {
                System.Threading.Thread.Sleep(4000);
                driver.SwitchTo().DefaultContent();
                driver.FindElement(By.Id("swalbtn1")).Click();
                System.Threading.Thread.Sleep(10000);
                driver.SwitchTo().Frame("ZonaInterna");
            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(10000);
                driver.SwitchTo().Frame("ZonaInterna");
            };

            return driver; 
        }
    }
}
