using System;

namespace Calculations
{

	/// <summary>
	/// Клас за формула за обикноввена строителна яма (Формула 01)</summary>
	public class Formula01
	{
		//Библиотеки
		private Colors.ForCLI _c = new Colors.ForCLI ();

		/// <summary>
		/// Конструктор на Формула 01</summary>

		public Formula01 () 
		{			
		}

		/// <summary>
		/// Метод за пресмятане на Формула 01</summary>
		/// <param name ="userInput">Това е цялата команда с параметри въведена от потребителя</param> 
		public void calc (string _userInput)
		{
			try {
				string[] param = _userInput.Split (' ');

				if (param.Length > 1 && _userInput.Contains ("-п") )
				{
					//Помощ за командаата
					help ();
				}

				if (param.Length > 1 && ! _userInput.Contains ("-п") )
				{
					//Изчисления
					double _result = 0;

					if ( runCalculations ( param, out _result ))
					{
						_c.Default (); Console.Write ("Обема на строителната яма е: ");
						_c.Result (); Console.WriteLine (_result.ToString ("N2"));
						_c.Default (); Console.WriteLine (" м3\n");

					}else{
						_c.Default (); Console.WriteLine ("Има грешно въведени прамеетри. Проверете синтаксиса с параметъра ' -п' ");
					}
				}


			} catch {				
			}
		}



		/// <summary>
		/// Вътрешен метод за пресмятане на Формула 01 след парсване на командата от потребителя</summary>
		/// <param name ="_param">Това е масив от стрингове, който съдържа командата с параметри от потребителя</param>
		/// <param name ="_result">В тази променлива ще бъде върнат резултата от формулата</param>
		/// >return<Методът връща true при успешно изпълнение</returns>
		private bool runCalculations (string[] _param, out double _result )
		{
			try {
				double _a1 = 0, _b1 = 0, _a2 = 0, _b2 = 0, _h = 0;



				//param[0] == <име на команда>
				Double.TryParse (_param[1], out _a1);
				Double.TryParse (_param[2], out _b1);
				Double.TryParse (_param[3], out _a2);
				Double.TryParse (_param[4], out _b2);
				Double.TryParse (_param[5], out _h);

				double F1 = _a1 * _b1, F2 = _a2 * _b2;
				_result = _h * (F1 +F2) / 2; 
				 

				return true;				
			}catch{				
			}
			_result = 0;
			return false; 
		}


		/// <summary>
		/// Вътрешен метод показващ синтаксиса на командата в командния ред.</summary>
		private void help ()
		{
			_c.Result (); Console.Write (" [яма] ");
			_c.Default (); Console.WriteLine (" - Команда за пресмятане на строителна яма");

			_c.Result (); Console.Write (" параметри: ");
			_c.Default (); Console.WriteLine (" a1 b1 a2 b2 h");

			_c.Result (); Console.Write (" a1 и b1 ");
			_c.Default (); Console.WriteLine (" - ширина и дължина на горната страна на изкопа\n");

			_c.Result (); Console.Write (" a2 и b2 ");
			_c.Default (); Console.WriteLine (" - ширина и дължина на долната страна на изкопа\n");

			_c.Result (); Console.Write (" h");
			_c.Default (); Console.WriteLine (" - дълбочина на изкопа");	
		}
	}
}
 
