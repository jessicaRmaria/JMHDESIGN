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

    [Key]
    public int IDprojfunc { get; set; }


    [ForeignKey("IDproj")]
    public int IDprojFK { get; set; }
    public Projetos IDproj { get; set; }

    [ForeignKey("IDfunc")]
    public int IDfuncFK { get; set; }
    public Funcionarios IDfunc { get; set; }

    }
}
