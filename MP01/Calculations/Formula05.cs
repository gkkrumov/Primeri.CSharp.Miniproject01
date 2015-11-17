using System;

namespace Calculations
{
	public class Formula05
	{
		//Библиотеки
		private Colors.ForCLI _c = new Colors.ForCLI ();   


		//Формула за канален изкоп
		public Formula05 ()
		{
		}

		public void calc ( string _input )
		{
			try {
				string[] param = _input.Split (' ');

				if (param.Length > 1 && _input.ToLower ().Contains ("-п")) 
				{ 
					//Помощ за командата
					help ();
				}

				if (param.Length > 1 && !_input.ToLower ().Contains ("-п"))
				{

					//Изчисления
					double _result = 0;

					if ( runCalculations (param, out _result ) )
					{
						_c.Default ();	Console.Write ("Обемът на каналния изкоп е: ");
						_c.Result ();	Console.Write ( _result.ToString ("N2") );
						_c.Default ();	Console.WriteLine ( " м3\n" );

					} else {
						_c.Default ();	Console.WriteLine ("Има грешно въведени параметри. С параметъра ' п' можете\nда видите синтаксиса на командата\n\n");																					 
					}
				}
				
			} catch {
			}
		}				

		private bool  runCalculations (string[] _param, out double _result)
		{
			try {
				double _a = 0, _b = 0, _h = 0, _L = 0;

				Double.TryParse (_param [1], out _a);         
				Double.TryParse (_param [2], out _b);         
				Double.TryParse (_param [3], out _h);       
				Double.TryParse (_param [4], out _L);       

				_result = (_a + _b) / 2 * _h * _L;

				return true;
			} catch {
			}

			_result = 0;
			return false;
		}
		//Помощ за командата
		private void help ()
		{
			_c.Result ();	Console.Write ("[кизкоп]");
			_c.Default ();	Console.WriteLine (" - команда за пресмятане на канален изкоп");

			_c.Command ();	Console.Write ("Параметри: ");
			_c.Default ();	Console.WriteLine ("a b h L\n ");

			_c.Command ();	Console.Write ("a и b");
			_c.Default ();	Console.WriteLine (" - горна и долна страна на изкопа ");

			_c.Command ();	Console.Write ("h ");
			_c.Default ();	Console.WriteLine (" - височина на каналния изкоп");

			_c.Command ();	Console.Write ("L ");
			_c.Default ();	Console.WriteLine (" - дължина на каналния изкоп\n");
		}
				
	}
}