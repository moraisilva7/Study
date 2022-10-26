using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTests
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Samara Morais";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Andre Silva", "ASD-9999", "azul", "Astra")]
        [InlineData("Samara Morais", "QWE-1234", "azul escuro", "Civic")]
        [InlineData("Lucas Souza", "ZXC-7890", "amarelo", "Fusca")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                     string placa,
                                                     string cor,
                                                     string modelo)
        {
            //Arrange 
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento );
        }

        //Pesquisa de veículo estacionado
        [Theory]
        [InlineData("Samara Morais", "QWE-1234", "azul escuro", "Civic")]
        public void LocalizaVeiculoNoPatio(string propritario,
                                           string placa,
                                           string cor,
                                           string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Samara Morais";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Lucas Souza";
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Lucas Souza";
            veiculoAlterado.Placa = "ASD-9999";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Fusca";

            //Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }


        
    }
}
