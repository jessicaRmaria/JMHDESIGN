using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class Clientes
    {

        public Clientes()
        {

            ListaProjetos = new HashSet<Projetos>();
            ListaFormularios = new HashSet<Formularios>();
        }


        [Key]
        public int IDcliente { get; set; }

        [Required]
        public string Nome { get; set; }

        
        public string Email { get; set; }

        [Required]
        public int Contacto { get; set; }

        [Required]
        public string Morada { get; set; }

        [Required]
        public string CodPostal { get; set; }

        [Required]
        public string NIF { get; set; }
        public ICollection<Projetos> ListaProjetos { get; set; }

        public ICollection<Formularios> ListaFormularios { get; set; }

        // ***********************************************************************************
        // relacionamento com os dados da autenticação
        // ***********************************************************************************
        /// <summary>
        /// Atributo utilizado para quando um Cliente se autentica, 
        /// relacionar esse cliente com os seus projetos
        /// </summary>
        public string UserNameId { get; set; }

    }
}
