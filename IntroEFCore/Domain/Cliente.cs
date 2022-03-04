using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntroEFCore.Domain
{
    public class Cliente
    {
        public Cliente()
        {
            
        }
        public Cliente(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public Cliente(string nome, string telefone, string cEP, string estado, string cidade, string email)
        {
            Nome = nome;
            Telefone = telefone;
            CEP = cEP;
            Estado = estado;
            Cidade = cidade;
            Email = email;
        }

        public Cliente(int id, string nome, string telefone, string cEP, string estado, string cidade, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CEP = cEP;
            Estado = estado;
            Cidade = cidade;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            string paraString = ""; 

            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                string valorCampo = propertyInfo.GetValue(this).ToString(); 
                paraString += $"{propertyInfo.Name}: {valorCampo}\n"; 
            }

            return paraString; 
        }
    }
}