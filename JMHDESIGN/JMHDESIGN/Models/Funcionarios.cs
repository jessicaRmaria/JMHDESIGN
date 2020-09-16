using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class Funcionarios {
        public Funcionarios() {

            // Estou a colocar dados na Lista de relacionamento de ProjetosFuncionarios
            ListaRelacionamento = new HashSet<ProjetosFuncionarios>();
        }

        /// <summary>
        /// ID do funcionário
        /// </summary>
        [Key]  
        public int IDfunc { get; set; }

        /// <summary>
        /// Nome do funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,5}",
                                ErrorMessage = "Deve escrever 2 a 6 nomes, começando por Maiúsculas, seguido de  minúsculas.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Cargo do funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        /// <summary>
        /// Contacto do funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Deve escrever exatamente {1} algarismos no {0}.")]
        [RegularExpression("[239][0-9]{8}", ErrorMessage = "Deve escrever um nº, com 9 algarismos, começando por 2, 3 ou 9.")]
        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        /// <summary>
        /// Morada do funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        /// <summary>
        /// Código Postal do funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("([0-9]{4}(-)[0-9]{3})(( | d[aeo](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,7}.*",
                ErrorMessage = "Deve escrever o código postal seguido da localidade ")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

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
        public ICollection<ProjetosFuncionarios> ListaRelacionamento { get; set; }

        }

}
