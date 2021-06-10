using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using QuiverPro.ClassesNavega;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
namespace QuiverPro
{
    class DadosLogin
    {
        public string licenca { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public DadosLogin()
        {
            licenca = "quiverproshift";
            usuario = "automacao";
            senha = "";
            
        }

        public IWebDriver LogarNoSistema()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://www.corretor-online.com.br");
            driver.FindElement(By.Id("Corretor")).SendKeys(licenca);
            driver.FindElement(By.Id("Usuario")).SendKeys(usuario);
            driver.FindElement(By.Id("Senha")).SendKeys(senha);
            driver.FindElement(By.Id("btnEntrar")).Click();

            return driver;
        }
    }
}
