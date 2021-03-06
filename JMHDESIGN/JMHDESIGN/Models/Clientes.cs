﻿using System;
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
            // Estou a colocar dados na Lista de projetos de cada cliente
            ListaProjetos = new HashSet<Projetos>();

            // Estou a colocar dados na Lista de formulários de cada cliente
            ListaFormularios = new HashSet<Formularios>();
        }

        /// <summary>
        /// ID do Cliente - Chave primária
        /// </summary>
        [Key]
        public int IDcliente { get; set; }


        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,5}",
                          ErrorMessage = "Deve escrever 2 a 6 nomes, começando por Maiúsculas, seguido de  minúsculas.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Email cliente
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Contacto cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Deve escrever exatamente {1} algarismos no {0}.")]
        [RegularExpression("[239][0-9]{8}", ErrorMessage = "Deve escrever um nº, com 9 algarismos, começando por 2, 3 ou 9.")]
        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        /// <summary>
        /// Morada do cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        /// <summary>
        /// Codigo Postal do cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("([0-9]{4}(-)[0-9]{3})(( | d[aeo](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,7}.*",
            ErrorMessage = "Deve escrever o código postal seguido da localidade ")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        /// <summary>
        /// NIF do cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Deve escrever exatamente {1} algarismos no {0}.")]
        [RegularExpression("[12567][0-9]{8}", ErrorMessage = "Deve escrever um nº, com 9 algarismos, começando por 1, 2, 5, 6 ou 7.")]
        [Display(Name = "NIF")]
        public string NIF { get; set; }

        /// <summary>
        /// Lista dos projetos associados a um cliente
        /// </summary>
        public ICollection<Projetos> ListaProjetos { get; set; }

        // ***********************************************************************************
        // relacionamento com os dados da autenticação
        // ***********************************************************************************
        /// <summary>
        /// Atributo utilizado para quando um Cliente se autentica, 
        /// relacionar esse cliente com os seus projetos
        /// </summary>
        public string UserNameId { get; set; }

        /// <summary>
        /// Lista de formulários associados a um cliente
        /// </summary>
        public ICollection<Formularios> ListaFormularios { get; set; }

       

    }
}
