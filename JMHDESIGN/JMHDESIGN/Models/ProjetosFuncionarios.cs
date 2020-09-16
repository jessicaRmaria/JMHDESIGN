using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class ProjetosFuncionarios
    {

    /// <summary>
    /// ID do ProjetoFuncionario
    /// </summary>  
    [Key]
    public int IDprojfunc { get; set; }

    /// <summary>
    /// Chave estrangeira
    /// </summary>  
    [ForeignKey("IDproj")]
    public int IDprojFK { get; set; }
    public Projetos IDproj { get; set; }

    /// <summary>
    /// Chave estrangeira
    /// </summary>  
    [ForeignKey("IDfunc")]
    public int IDfuncFK { get; set; }
    public Funcionarios IDfunc { get; set; }

    }
}
