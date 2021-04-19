using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using QuiverPro.ClassesNavega;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

namespace QuiverPro.ClassesNavega
{
    class CadastroPremio
    {
        //Classe para cadastro de premio temos um metodo para cadastro simples. no futuro terá cadastro de prêmio com co-corretor
        public IWebDriver CadastraPremio(IWebDriver driver, NavegaMenu navega, double comissaoBase,double desconto,double premioLiquido)
        {
            #region Cadastro de prêmio.
            {
           

                System.Threading.Thread.Sleep(2000);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("ZonaInterna");
                System.Threading.Thread.Sleep(2000);
                driver = navega.NavegaScroll(driver, "TitPremios");

                driver.FindElement(By.Id("TitPremios")).Click();

                System.Threading.Thread.Sleep(2000);
                IWebElement meioPagamento = driver.FindElement(By.Id("Documento_MeioPagto"));
                SelectElement comboMeioPag = new SelectElement(meioPagamento);
                comboMeioPag.SelectByValue("7");
                driver.FindElement(By.Id("Documento_QtdeParcPremio")).Clear();
                driver.FindElement(By.Id("Documento_QtdeParcPremio")).SendKeys("12");
                driver.FindElement(By.Id("Documento_ParcelaInicial")).Clear();
                driver.FindElement(By.Id("Documento_ParcelaInicial")).SendKeys("1");
                driver.FindElement(By.Id("Documento_FormaPagamento1")).Click();
                driver.FindElement(By.Id("Documento_TipoDesc0")).Click();
                DateTime dtDiasVencPriParc = DateTime.Today.AddDays(5);
                driver.FindElement(By.Id("Documento_DiasVencPrimeira")).Clear();
                driver.FindElement(By.Id("Documento_DiasVencPrimeira")).SendKeys(dtDiasVencPriParc.Day.ToString());
                driver.FindElement(By.Id("Documento_PercComBase")).SendKeys(Keys.Control + "a");
                driver.FindElement(By.Id("Documento_PercComBase")).SendKeys(comissaoBase.ToString());
                driver.FindElement(By.Id("Documento_PercDesconto")).SendKeys(Keys.Control + "a");
                driver.FindElement(By.Id("Documento_PercDesconto")).SendKeys(desconto.ToString());
                driver.FindElement(By.Id("Documento_PercDesconto")).SendKeys(Keys.Tab);
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.Id("Documento_PremioLiqDesc")).SendKeys(Keys.Control + "a");
                driver.FindElement(By.Id("Documento_PremioLiqDesc")).SendKeys(premioLiquido.ToString());
                System.Threading.Thread.Sleep(2000);
                driver = navega.BtnGravar(driver);
                return driver;
            }
            #endregion
        }
    }
}
