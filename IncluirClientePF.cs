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
    /// Descrição resumida para IncluirClientePF
    /// cadastro e validação de todas as opções do cadastro do cliente PF.
    /// </summary>
    
    [TestClass]
    public class IncluirClientePF
    {
       
        [TestMethod]
        public void IncluirClientePf()
        {

            #region classes utilizadas.
            //Classe que faz login no sistema.
            DadosLogin login = new DadosLogin();
            //Classe instanciada para os metodos de navegação.
            NavegaMenu navega = new NavegaMenu();
            //Classe instanciada para gerar numero cpf aleatório.
            GeradorCpfCnpj Cpf = new GeradorCpfCnpj();
            #endregion

            //login no sistema.
            IWebDriver driver = login.LogarNoSistema();
            //Esperando tela de inicio carregar.
            System.Threading.Thread.Sleep(8000);


            string cpf = "";
            int fase = 0;
            int cad = 1;
            while (fase < 2)
            { 
                if(fase == 1) {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().DefaultContent();
                }
                //navegando até o operacional.
                driver = navega.NavegaOperacional(driver);

            //comando para acesso ao iframe 
            driver.SwitchTo().Frame("ZonaInterna");
            //escolhendo o menu por javascript executando função diretamente.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("SelecionaModuloJQuery('ConsultaCliente;Fast/FrmCadastroNovo.aspx?pagina=Cliente1', 'CLIENTE', 'Professional|Beneficios', 'CLIENTE', 'Clientes');");
            System.Threading.Thread.Sleep(5000);

                if(cad == 1) { 
                 //Clica no botão incluir.
                driver.FindElement(By.Id("BtIncluir")).Click();

            #region Cadastro dos dados do cliente.
            #region Dados principais
            //comando para acesso ao iframe 
            driver.SwitchTo().Frame("ZonaInterna");
            driver.FindElement(By.Id("Cliente_Nome")).SendKeys("Lucas Teste Automacao");
            cpf = Cpf.CadastroPF();
            driver.FindElement(By.Id("Cliente_CgcCpf")).SendKeys(cpf);
            driver.FindElement(By.Id("Cliente_Sexo1")).Click();

                    {//para clicar e selecionar grupo de produção
                        driver.FindElement(By.XPath("//*[@id=\"DIVCliente_GrupoHierarquico\"]/div/span/span[1]/span")).Click();
                        driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("quiver");
                        System.Threading.Thread.Sleep(2000);
                        driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                        driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
                    }
            
            //Selecionando caracteristica. quase chorei pra fazer funcionar.
            IWebElement elemento = driver.FindElement(By.Id("Cliente_Caracteristica"));
            SelectElement combo = new SelectElement(elemento);
            combo.SelectByIndex(2);
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("Cliente_EMail")).SendKeys("testeauto@testeauto.com.br");
            #endregion
            System.Threading.Thread.Sleep(2000);
            #region Dados Complementares.
            //driver.FindElement(By.Id("DadosComplementares_Box")).Click();
                    js.ExecuteScript("openAtalho(\"BoxDadosComplementares\");");
                   
                    
                    driver.FindElement(By.Id("Cliente_InscrEstadual")).SendKeys(Cpf.GerarRG());
            driver.FindElement(By.Id("Cliente_DataNascimento")).SendKeys("01/01/1995");

            //Selecionando documento de identidade. quase chorei pra fazer funcionar.
            IWebElement comboDocIdent = driver.FindElement(By.Id("Cliente_TipoIdent"));
            SelectElement cbDocIdent = new SelectElement(comboDocIdent);
            cbDocIdent.SelectByIndex(6);
            
            //data de exp rg e orgão exp.
            driver.FindElement(By.Id("Cliente_DataExp")).SendKeys("01/01/2000");
            driver.FindElement(By.Id("Cliente_OrgaoExp")).SendKeys("SSP");
            driver.FindElement(By.Id("BtGravar")).Click();
                    #endregion


                    #region Cadastro de endereço e telefone.

                    { //Cadastro de telefone.
                        driver.FindElement(By.Id("BtIncluirClienteTelefone1")).Click();
                        System.Threading.Thread.Sleep(2000);
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.FindElement(By.Id("ClienteFone_DDD")).SendKeys("11");
                        driver.FindElement(By.Id("ClienteFone_Telefone")).SendKeys("12345678");
                        //Selecionando telefone em combo. quase chorei pra fazer funcionar.
                        elemento = driver.FindElement(By.Id("ClienteFone_TipoTelefone"));
                        combo = new SelectElement(elemento);
                        combo.SelectByIndex(8);

                        driver.FindElement(By.Id("ClienteFone_FonePref")).Click();

                        driver.FindElement(By.Id("BtGravar")).Click();
                        driver.FindElement(By.Id("Button1")).Click();
                    }
                    { //Cadastro de Endereço
                        System.Threading.Thread.Sleep(5000);

                        //após clicar do sair tive qeu voltar para default e depois acessar 2 iframes
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.FindElement(By.Id("BtIncluirClienteEndereco1")).Click();
                        System.Threading.Thread.Sleep(5000);
                        driver.SwitchTo().Frame("ZonaInterna");
                        driver.FindElement(By.Id("ClienteEnder_Cep")).SendKeys("01227000");
                        driver.FindElement(By.Id("ClienteEnder_Complemento")).Click();
                        System.Threading.Thread.Sleep(5000);
                        driver.FindElement(By.Id("ClienteEnder_Numero")).SendKeys("171");
                        driver.FindElement(By.Id("BtGravar")).Click();
                        driver.FindElement(By.Id("Button1")).Click();

                    }
                    #endregion

                    #endregion

                    cad = 2;
                    fase++;
                }
                #region Validação do cadastro do cliente mediante a consulta.
                else
                {
                    //aqui não precisou selecionar o zona interna pois ele já veio carregado lá de cima do código.
                    //Selecionando tipo de consulta de cliente.                     
                    System.Threading.Thread.Sleep(2000);
                    IWebElement elemento = driver.FindElement(By.Name("TipoConsultaWeb"));
                    SelectElement combo = new SelectElement(elemento);
                    combo.SelectByIndex(3);
                    driver.FindElement(By.Id("CgcCpfCli")).SendKeys(cpf);
                    driver.FindElement(By.XPath("//*[@id=\"SpanToolBarRightB\"]/button")).Click();                  
                    //Espera necessária para gerar o elemento na tela.
                    System.Threading.Thread.Sleep(3000);
                    driver.FindElement(By.Id("BtEdiReg")).Click();
                    fase++;
                   // System.Threading.Thread.Sleep(10000);

                    
                }
                #endregion
            }
        }
    }
}
