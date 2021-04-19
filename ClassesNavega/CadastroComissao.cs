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
    class CadastroComissao
    {

       public IWebDriver ValidaComRepNormalParc(IWebDriver driver,NavegaMenu navega)
        {
            //função valida cálculo de comissão, repasse e parcelas.
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("ZonaInterna");
            driver.SwitchTo().Frame("ZonaInterna");
            System.Threading.Thread.Sleep(8000);
            driver = navega.NavegaScroll(driver, "TitPremios");
            driver.FindElement(By.Id("TitPremios")).Click();
            System.Threading.Thread.Sleep(5000);

            double percComissao = double.Parse(driver.FindElement(By.Id("Documento_PercComissao")).GetAttribute("value"));
            double valorPremLiquido = double.Parse(driver.FindElement(By.Id("Documento_PremioLiqDesc")).GetAttribute("value"));

            //Navegando até a div de comissões.
            driver = navega.NavegaScroll(driver, "TitComissoes");
            driver.FindElement(By.Id("TitComissoes")).Click();
            double valorComissao = double.Parse(driver.FindElement(By.Id("Documento_Comissao")).GetAttribute("value"));
            double res = valorPremLiquido * (percComissao / 100);

            if (Math.Round(res, 2) == valorComissao || (valorComissao - Math.Round(res, 2)) == 0.01 || (valorComissao - Math.Round(res, 2)) == -0.01)
            {
                //Acessa o botão produtores.
                driver.FindElement(By.Id("BtProdutores")).Click();
                //volta para o body inicial.
                driver.SwitchTo().DefaultContent();
                System.Threading.Thread.Sleep(3000);
                //seleciona o scopo do iframe de repasses 
                driver.SwitchTo().Frame("DocumentoRepasse");
                System.Threading.Thread.Sleep(3000);
                //Seleciona o produtor baseado no title contendo o nome do produtor.
                driver.FindElement(By.XPath("//*[contains(@title, 'WELLINGTON CARDOSO')]")).Click();

                //driver.SwitchTo().Frame("DocumentoRepasse");
                System.Threading.Thread.Sleep(2500);
                //iniciado o processo de validação da quantidade de parcelas.
                string docparcrep = driver.FindElement(By.Id("DocumentoRep_QtdeParcelas")).GetAttribute("value");
                int qtdParcRep = int.Parse(docparcrep);
                // pega o valor base de cálculo para o repasse.
                double valorBaseRep = double.Parse(driver.FindElement(By.Id("DocumentoRep_ValorBase")).GetAttribute("value"));
                double percentualRep = double.Parse(driver.FindElement(By.Id("DocumentoRep_PercRepasse")).GetAttribute("value"));
                double valorParcelaRepasse = (valorBaseRep * (percentualRep / 100)) / qtdParcRep;
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("DocumentoRepasse");
                System.Threading.Thread.Sleep(2000);
                driver = navega.NavegaScroll(driver, "labelDocumentoRep_Inclusao_Automatica");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.Id("TitDocumentoRepasseParc")).Click();
                System.Threading.Thread.Sleep(2000);
                double somaRep = 0;
                System.Threading.Thread.Sleep(3000);
                int j = 2;
                bool validaParcRep = false;
                for (int i = 0; i < qtdParcRep; i++)
                {

                    System.Threading.Thread.Sleep(2000);
                    driver.SwitchTo().Frame("FrameDocumentoRepasseParc");
                    driver.FindElement(By.XPath("/html/body/form/div[3]/div/span[1]/span/div/div[3]/div[3]/div/table/tbody/tr[" + j.ToString() + "]/td[1]/a")).Click();
                    j++;
                    System.Threading.Thread.Sleep(3000);
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame("DocumentoRepasse");
                    driver.SwitchTo().Frame("ZonaInterna");
                    System.Threading.Thread.Sleep(3000);
                    driver.FindElement(By.Id("DocumentoParcRep_Operacao1")).Click();
                    somaRep = double.Parse(driver.FindElement(By.Id("DocumentoParcRep_Valor")).GetAttribute("value"));
                    double y = somaRep;
                    somaRep += somaRep;
                    string valorParcRepCompare = Math.Round(valorParcelaRepasse, 2).ToString();
                    string validaParcRepValor = driver.FindElement(By.Id("DocumentoParcRep_Valor")).GetAttribute("value");


                    if (validaParcRepValor == valorParcRepCompare)
                    {
                        Assert.AreEqual(validaParcRepValor, valorParcRepCompare);
                        validaParcRep = true;
                    }

                    //caso o valor tenha diferença ele testa a conta com + ou - 1 centavo de tolerancia.

                    if (Math.Round(y - Math.Round(valorParcelaRepasse, 2), 2) == 0.01)
                    {
                        valorParcRepCompare = Math.Round(valorParcelaRepasse, 2) + 0.01.ToString();
                        Assert.AreEqual(validaParcRepValor, valorParcRepCompare);
                        validaParcRep = true;
                    }

                    if (Math.Round(y - Math.Round(valorParcelaRepasse, 2), 2) == -0.01)
                    {
                        valorParcRepCompare = Math.Round(valorParcelaRepasse - 0.01, 2).ToString();
                        Assert.AreEqual(validaParcRepValor, valorParcRepCompare);
                        validaParcRep = true;

                    }

                    Assert.IsTrue(validaParcRep);

                    driver.FindElement(By.Id("Button1")).Click();
                    System.Threading.Thread.Sleep(4000);
                    driver.SwitchTo().DefaultContent();
                    driver.FindElement(By.XPath("/html/body/div[5]/div/div[3]/button[1]")).Click();
                    System.Threading.Thread.Sleep(10000);
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame("DocumentoRepasse");
                    System.Threading.Thread.Sleep(2000);
                    driver = navega.NavegaScroll(driver, "labelDocumentoRep_Inclusao_Automatica");
                    System.Threading.Thread.Sleep(2000);

                }

            }

            return driver;

        }
    }
}
