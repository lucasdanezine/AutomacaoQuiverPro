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
    /// Descrição resumida para IncluiPropSegNovo
    /// </summary>
    [TestClass]
    public class IncluiPropSegNovo
    {

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IncluirSegNovo()
        {
            #region Classes utilizadas para login e navegação ate o modulo.
            //Classe que faz login no sistema.
            DadosLogin login = new DadosLogin();
            //Classe instanciada para os metodos de navegação.
            NavegaMenu navega = new NavegaMenu();
            #endregion

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

            //IWebElement selecionaConsultaDoc = driver.FindElement(By.Id("TipoConsulta2"));
            // SelectElement comboConsultaDoc = new SelectElement(selecionaConsultaDoc);
            //comboConsultaDoc.SelectByValue("2");
            // driver.FindElement(By.Id("NoApolice")).SendKeys(apolice);
            //driver.FindElement(By.XPath("//*[@id=\"SpanToolBarRightB\"]/button")).Click();


            driver.FindElement(By.Id("BtIncluir")).Click();

            System.Threading.Thread.Sleep(5000);

            //Driver entrando no iframe para acesso ao form de cadastro.
            driver.SwitchTo().Frame("ZonaInterna");
            #region Cadastro capa do doc
            {//processo para clicar e selecionar em combos dinamicos.
                driver.FindElement(By.XPath("//*[@id=\"DIVDocumento_Cliente\"]/div/span/span[1]/span")).Click();

                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("CADASTRO ROBO PARA INCLUIR SEGUROS");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            }


            driver.FindElement(By.Id("Documento_Apolice")).SendKeys(apolice);
            //Selecionando seguradora.
            IWebElement seguradora = driver.FindElement(By.Id("Documento_Seguradora"));
            SelectElement comboSeguradora = new SelectElement(seguradora);
            comboSeguradora.SelectByValue("10126");
            System.Threading.Thread.Sleep(2000);
            //
            IWebElement produto = driver.FindElement(By.Id("Documento_Produto"));
            SelectElement comboProduto = new SelectElement(produto);
            comboProduto.SelectByValue("553");

            {//para clicar e selecionar grupo de produção
                driver.FindElement(By.XPath("//*[@id=\"DIVDocumento_GrupoHierarquico\"]/div/span/span[1]/span")).Click();
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("quiver");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            }
            {// Executa a inclusão do inicio de vigência. 
             // Pega o dia da execução e usa como vigencia.
                DateTime iniVigencia = DateTime.Today;
                driver.FindElement(By.Id("Documento_InicioVigencia")).SendKeys(iniVigencia.ToString());
                driver.FindElement(By.Id("Documento_InicioVigencia")).SendKeys(Keys.Tab);
                driver.FindElement(By.Id("Documento_DataEmissao")).SendKeys(iniVigencia.ToString());
                driver.FindElement(By.Id("Documento_TipoNegocio1")).Click();
                System.Threading.Thread.Sleep(1000);
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


            }
            #endregion
            #region Cadastro Item.
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
                    driver.FindElement(By.Id("DocumentoIte_AnoModelo")).SendKeys(Keys.Backspace);
                    driver.FindElement(By.Id("DocumentoIte_AnoModelo")).SendKeys("2015");
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

                        
                        driver.FindElement(By.Id("DocumentoIteCob_DetalheCob")).SendKeys("teste complemento.");
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


            }
            #endregion
        }
    }
}
