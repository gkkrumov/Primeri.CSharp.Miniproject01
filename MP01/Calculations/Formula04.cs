using System;

namespace Calculations
{
	public class Formula04
	{
		Colors.ForCLI _cl = new Colors.ForCLI ();

		public Formula04 ()
		{
		}

		public void calc ( string _input )
		{
			try
			{
				string[] param = _input.Split (' ');

				if ( param.Length > 1 && _input.ToLower().Contains ("-п"))
				{
					help ();
				}

				if ( param.Length == 4 )
				{
					double result = 0;
					if ( runCalculate ( param, out result ) )
					{
						_cl.Default ();Console.Write ("Обемът на страничния ъгъл е ");
						_cl.Result ();Console.Write (result.ToString ("N2"));
						_cl.Default ();Console.WriteLine (" м3\n ");
					}else{
						_cl.Default ();  Console.WriteLine ("Има грешно въведени параметри. С параметъра ' п' можете\nда видите синтаксиса на командата\n");																					 
					}				
				}
			}catch{
			}
		}

		private bool  runCalculate (string[] _param, out double _result)
		{

			try
			{
				double a = 0; Double.TryParse ( _param[1], out a);
				double h = 0; Double.TryParse ( _param[2], out h);
				double L = 0; Double.TryParse ( _param[3], out L);

				_result = ( a * h/2 ) * L;

				return true;
			}catch{
			}

			_result = 0;
			return false;
		}

		private void help ()
		{
			_cl.Result ();      Console.Write ("[стъгъл]");
			_cl.Default ();     Console.WriteLine (" - Страничен ъгъл");

			_cl.Command ();     Console.Write ( "параметри: ");
			_cl.Default ();     Console.WriteLine ("a, h и L");

			_cl.Command ();     Console.Write ("a");
			_cl.Default ();     Console.WriteLine (" - ширина на профила");

			_cl.Command ();     Console.Write ("h");
			_cl.Default ()      ;Console.WriteLine (" - височина");

			_cl.Command ();     Console.Write ("L");
			_cl.Default ();     Console.WriteLine (" - дължина\n");

		}
	}
}


