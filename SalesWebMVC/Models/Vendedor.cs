using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Venda> Venda { get; set; } = new List<Venda>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Salario = salario;
            Departamento = departamento;
        }

        public void AdcVenda(Venda sr)
        {
            Venda.Add(sr);
        }

        public void RemoverVenda(Venda sr)
        {
            Venda.Remove(sr);
        }

        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Venda.Where(x => x.Data >= inicio && x.Data <= final).Sum(x => x.ValorVenda);
        }
    }
}
