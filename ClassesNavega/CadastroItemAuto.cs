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
    class CadastroItemAuto
    {
        /// <summary>
        /// Essa classe tem o objetivo de cadastrar o item para cadastros de propostas/apólices do tipo de controle automóvel.
        /// </summary>
        /// <param name="navega"></param>
        /// <returns>retorna o cadastro completo do item,coberturas e condutor.</returns>

        public IWebDriver CadItemAuto(IWebDriver navega)
        {
            IWebDriver driver = navega;
            {//Cadastro do item.
                System.Threading.Thread.Sleep(2000);
                driver.SwitchTo().Frame("ZonaInterna");
                driver.FindElement(By.Id("icone-DocumentoItemVeiculo")).Click();
                driver.FindElement(By.Id("BtIncluirDocumentoItemVeiculo")).Click();
                {//Selecionando marca e modelo. 
                    System.Threading.Thread.Sleep(4000);
                    driver.SwitchTo().Frame("ZonaInterna");
                    IWebElement fabricante = driver.FindElement(By.Id("DocumentoIte_Fabricante"));
                    SelectElement comboFabricante = new SelectElement(fabricante);
                    comboFabricante.SelectByValue("91");
                    System.Threading.Thread.Sleep(3000);

                    {//clica na lupa para buscar o veiculo.
                        driver.FindElement(By.Id("DocumentoIte_Modelo_Bt")).Click();
                        System.Threading.Thread.Sleep(4000);
                        //Acessa o frame do item.
                        driver.SwitchTo().Frame("SearchVeiculoModelo1");
                        //Busca por xpath.
                        driver.FindElement(By.XPath("/html/body/form/div[5]/div[1]/div/div[2]/div[1]/div/div/input")).SendKeys("ESPERO SEDAN CD 550");
                        driver.FindElement(By.XPath("//*[@id=\"SpanToolBarRightB\"]/button")).Click();
                        System.Threading.Thread.Sleep(2000);
                        driver.FindElement(By.Id("BtEdiReg")).Click();
                    }
                    System.Threading.Thread.Sleep(2000);
                    driver.SwitchTo().Frame("ZonaInterna");
                    driver.SwitchTo().Frame("ZonaInterna");
                    driver.SwitchTo().Frame("ZonaInterna");
                    System.Threading.Thread.Sleep(1500);
                    driver.FindElement(By.Id("DocumentoIte_AnoFabricacao")).SendKeys(Keys.Backspace);
                    driver.FindElement(By.Id("DocumentoIte_AnoFabricacao")).SendKeys("2014");
                    System.Threading.Thread.Sleep(1500);
                    driver.FindElement(By.Id("DocumentoIte_AnoFabricacao")).SendKeys(Keys.Tab);
                    driver.FindElement(By.Id("DocumentoIte_AnoModelo")).SendKeys("2015");
                    driver.FindElement(By.Id("DocumentoIte_AnoModelo")).SendKeys(Keys.Tab);
                    System.Threading.Thread.Sleep(10000);
                    driver.FindElement(By.Id("DocumentoIte_TipoCombustivel5")).Click();
                    driver.FindElement(By.Id("DocumentoIte_Placa")).SendKeys("ABC12345");
                    driver.FindElement(By.Id("DocumentoIte_Chassi")).SendKeys("12345678901234567");
                    driver.FindElement(By.Id("DocumentoIte_Renavam")).SendKeys(Keys.Backspace);
                    driver.FindElement(By.Id("DocumentoIte_Renavam")).SendKeys("22652959335");
                    driver.FindElement(By.Id("BtGravar")).Click();

                    {//Coberturas automovel.

                        System.Threading.Thread.Sleep(1500);
                        driver.FindElement(By.Id("BtIncluirDocumentoItemVeiculoCob")).Click();
                        System.Threading.Thread.Sleep(4000);
                        driver.SwitchTo().Frame("ZonaInterna");

                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("DocumentoIteCob_ImpSegurada")).SendKeys(Keys.Control + "A");
                        driver.FindElement(By.Id("DocumentoIteCob_ImpSegurada")).SendKeys(Keys.Delete);
                        driver.FindElement(By.Id("DocumentoIteCob_ImpSegurada")).SendKeys("1000,00");

                        IWebElement tabFipe = driver.FindElement(By.Id("DocumentoIteCob_TabCotacao"));
                        SelectElement comboFipe = new SelectElement(tabFipe);
                        comboFipe.SelectByValue("1");



                        IWebElement franquia = driver.FindElement(By.Id("DocumentoIteCob_TipoFranquia"));
                        SelectElement comboFranquia = new SelectElement(franquia);
                        comboFranquia.SelectByValue("1");

                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("DocumentoIteCob_ValorFranquia")).SendKeys(Keys.Control + "A");
                        driver.FindElement(By.Id("DocumentoIteCob_ValorFranquia")).SendKeys(Keys.Delete);
                        driver.FindElement(By.Id("DocumentoIteCob_ValorFranquia")).SendKeys("1000,00");
                        driver.FindElement(By.Id("DocumentoIteCob_PercFranquia")).SendKeys(Keys.Control + "A");
                        driver.FindElement(By.Id("DocumentoIteCob_PercFranquia")).SendKeys(Keys.Delete);
                        driver.FindElement(By.Id("DocumentoIteCob_PercFranquia")).SendKeys("100");
                        driver.FindElement(By.Id("DocumentoIteCob_FranquiaMinima")).SendKeys(Keys.Control + "A");
                        driver.FindElement(By.Id("DocumentoIteCob_FranquiaMinima")).SendKeys(Keys.Delete);
                        driver.FindElement(By.Id("DocumentoIteCob_FranquiaMinima")).SendKeys("200");
                        string textoDetalha = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam fringilla molestie lectus sed condimentum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer quam tortor, venenatis blandit consectetur quis, mollis nec odio. Duis aliquet neque tempor orci rutrum, et feugiat diam facilisis. Sed nec nulla sed nunc placerat eleifend nec ut libero. Pellentesque interdum orci in enim hendrerit pulvinar. In odio augue, hendrerit quis lorem ac, tincidunt sollicitudin ante. Morbi vitae ultrices risus.";
                        driver.FindElement(By.Id("DocumentoIteCob_DescrFranquia")).SendKeys(textoDetalha);
                        System.Threading.Thread.Sleep(5000);
                        IWebElement cobertura = driver.FindElement(By.Id("DocumentoIteCob_Cobertura"));
                        SelectElement comboCobertura = new SelectElement(cobertura);
                        comboCobertura.SelectByValue("346");
                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("DocumentoIteCob_TemFranquia")).Click();
                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("DocumentoIteCob_DetalheCob")).SendKeys("teste complemento.");
                        driver.FindElement(By.Id("BtGravar")).Click();
                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("Button1")).Click();
                    }
                    {//Cadastro Condutor.
                        System.Threading.Thread.Sleep(3000);
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.FindElement(By.Id("BtIncluirDocsItensAutoCond")).Click();
                        System.Threading.Thread.Sleep(4000);
                        driver.SwitchTo().DefaultContent();
                        driver.FindElement(By.Id("swalbtn1")).Click();
                        System.Threading.Thread.Sleep(3000);
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.FindElement(By.Id("BtGravar")).Click();
                        System.Threading.Thread.Sleep(3000);
                        driver.FindElement(By.Id("Button1")).Click();
                    }

                    {// voltando para a tela do cadastro de seguro.
                        System.Threading.Thread.Sleep(3000);
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");

                        driver.FindElement(By.Id("Button1")).Click();
                    }

                }
                return driver;
            }
        }

    }
}