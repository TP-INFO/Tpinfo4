using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4 {
  public class Morpion {

    public int NRows { get; set; }
    public int NCollumns { get; set; }
    /// <summary>
    /// Character representing PC player 
    /// </summary>
    public Char PCChar { get; set; }  
    /// <summary>
    /// Character representing Human player
    /// </summary>
    public Char USerChar { get; set; }

    /// <summary>
    /// Default constructor: Creates a Morpion board with defualt size of 3x3;
    /// </summary>

    public Morpion() {
      NRows = 3;
      NCollumns = 3;
    }
    /// <summary>
    /// Creates a Morpion Board with custom size;
    /// </summary>
    /// <param name="nrows"><value>Number of rows in the board</value></param>
    /// <param name="ncolumns"><value>Number of collumns in the board</value></param>

    public Morpion(int nrows, int ncolumns) {
      NRows = nrows;
      NCollumns = ncolumns;
    }



    #region Methods








    #endregion






  }


}
