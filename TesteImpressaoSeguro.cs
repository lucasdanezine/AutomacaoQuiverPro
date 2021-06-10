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

namespace QuiverPro
{
    /// <summary>
    /// Descrição resumida para TesteImpressaoSeguro
    /// </summary>
    [TestClass]
    public class TesteImpressaoSeguro
    {
        [TestMethod]
        public void TesteImpressaoSeguroNovo()
        {
            #region Classes utilizadas para login e navegação ate o modulo.
            //Classe que faz login no sistema.
            DadosLogin login = new DadosLogin();
            //Classe instanciada para os metodos de navegação.
            NavegaMenu navega = new NavegaMenu();
            #endregion
            int x = 0;
            while (x < 2)
            {
                //login no sistema.
                IWebDriver driver = login.LogarNoSistema();
                //Esperando tela de inicio carregar.
                System.Threading.Thread.Sleep(8000);

                //navega ao menu operacional.
                driver = navega.NavegaOperacional(driver);

                //comando para acesso ao iframe 
                driver.SwitchTo().Frame("ZonaInterna");
                //escolhendo o menu por javascript executando função diretamente.
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("SelecionaModuloJQuery('ConsultaEmissaoERecusa;Fast/FrmCadastroNovo.aspx?pagina=Documento','EMISSOESRECUSAS','Professional','EMISSOESRECUSAS','Propostas/Apólices'); ");
                System.Threading.Thread.Sleep(5000);

                //gerando o número de apólice, ROB+DATA DO CADASTRO+AT (Apolice Tipo) e o número 1 de seguro novo. 

                string apolice = "";
                int n = 1;

                DateTime numeroApolice = DateTime.Today;
                apolice = "ROB" + numeroApolice.ToString("dd/MM/yyyy") + "AT" + n;

                IWebElement selecionaConsultaDoc = driver.FindElement(By.Id("TipoConsulta2"));
                SelectElement comboConsultaDoc = new SelectElement(selecionaConsultaDoc);
                comboConsultaDoc.SelectByValue("2");
                driver.FindElement(By.Id("NoApolice")).SendKeys(apolice);
                driver.FindElement(By.XPath("//*[@id=\"SpanToolBarRightB\"]/button")).Click();
                System.Threading.Thread.Sleep(2500);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("ZonaInterna");
                driver.FindElement(By.Id("BtEdiReg")).Click();
                System.Threading.Thread.Sleep(3500);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("ZonaInterna");
                driver.FindElement(By.Id("BtImprimir")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("RptImpressaoProposta");

                switch (x)
                {
                    case 0:
                        driver.FindElement(By.Id("ViasImpressao1")).Click();
                        break;
                    case 1:
                        driver.FindElement(By.Id("ViasImpressao2")).Click();
                        break;
                }

                for (int i = 1; i <= 5; i++)
                {
                    driver.FindElement(By.XPath("/html/body/form/div[5]/div[1]/div/div/div/div[2]/div[1]/div[2]/div/div[" + i + "]/div/div/input")).Click();
                }

                driver.FindElement(By.Id("BtAnexar")).Click();
                System.Threading.Thread.Sleep(15000);
                driver.SwitchTo().DefaultContent();
                string validaResultadoImp = driver.FindElement(By.XPath("//*[@id=\"dialog_janela\"]/div/div/div[1]/h5")).Text;
                Assert.AreEqual(validaResultadoImp, "Relatório");
                driver.Quit();
                x++;
            }
        }
    }
}
