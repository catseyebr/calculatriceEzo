﻿using CalculatriceEzo.Operations;

namespace CalculatriceEzo
{
    public class Calculatrice
    {
        private readonly Dictionary<string, IOperation> _operations;
        private readonly Dictionary<string, IUnitaireOperation> _uniOperations;
        public Calculatrice()
        {
            _operations = new Dictionary<string, IOperation>
            {
                { "+", new Addition() },
                { "-", new Subtraction()},
                { "*", new Multiplication()},
                { "/", new Division()},
                { "^", new Power()}
            };

            _uniOperations = new Dictionary<string, IUnitaireOperation>
            {
                { "sqrt", new SquareRoot() }
            };
        }

        public double EvaluerExpression(string expression)
        {
            expression = ResoudreUnitaireOps(expression);
            expression = ResoudreParentheses(expression);

            var elements = ClassifierExpression(expression);
            return Calculate(elements);
           
        }

        private string ResoudreParentheses(string expression)
        {
            expression = expression.Replace(" ", "");

            while(expression.Contains("("))
            {
                int start = expression.LastIndexOf('(');
                int end = expression.IndexOf(')', start);

                if (end == -1) throw new ArgumentException("Parenthèses déséquilibrées!");

                string subExpression = expression.Substring(start + 1, end - start - 1);
                var elements = ClassifierExpression(subExpression);
                double subresult = Calculate(elements);

                expression = expression.Substring(0, start) + subresult + expression.Substring(end + 1);
            }

            return expression;
        }

        private string ResoudreUnitaireOps(string expression)
        {
            foreach (var op in _uniOperations)
            {
                while (expression.Contains(op.Key))
                {
                    int start = expression.IndexOf(op.Key) + op.Key.Length;
                    if (expression[start] != '(') throw new ArgumentException($"L’operation {op.Key} doit être suivie de parenthèses!");

                    int end = expression.IndexOf(')', start);
                    if (end == -1) throw new ArgumentException($"Parenthèses déséquilibrées pour l’operation {op.Key}!");

                    string subExpression = expression.Substring(start + 1, end - start - 1);
                    double value = op.Value.Execute(Convert.ToDouble(subExpression));

                    expression = expression.Substring(0, expression.IndexOf(op.Key)) + value + expression.Substring(end+1);
                }
            }
            return expression;
        }

        private List<string> ClassifierExpression(string expression)
        {
            var elements = new List<string>();
            string chiffre = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c) || c == '.')
                {
                    chiffre += c;
                }
                else if (c == '-' && (i == 0 || "+-".Contains(expression[i -1])))
                {
                    chiffre += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(chiffre))
                    {
                        elements.Add(chiffre);
                        chiffre = "";
                    }
                    elements.Add(c.ToString());
                }
            }

            if(!string .IsNullOrEmpty(chiffre)) elements.Add(chiffre);
            return elements;
        }

        private double Calculate(List<string> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (_operations.ContainsKey(elements[i]))
                {
                    string ope = elements[i];

                    if (ope == "^" || ope == "*" || ope == "/")
                    {
                        double a = Convert.ToDouble(elements[i - 1].Replace(".", ","));
                        double b = Convert.ToDouble(elements[i + 1].Replace(".", ","));
                        double result = _operations[ope].Execute(a, b);

                        elements[i - 1] = result.ToString();
                        elements.RemoveAt(i + 1);
                        elements.RemoveAt(i);
                        i--;
                    }
                }
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (_operations.ContainsKey(elements[i]))
                {
                    string ope = elements[i];
                    
                    if(ope == "+" || ope == "-")
                    {
                        double a = Convert.ToDouble(elements[i - 1]);
                        double b = Convert.ToDouble(elements[i + 1]);
                        double result = _operations[ope].Execute(a, b);

                        elements[i - 1] = result.ToString();
                        elements.RemoveAt(i + 1);
                        elements.RemoveAt(i);
                        i--;
                    }
                }
            }

            return Math.Round(Convert.ToDouble(elements[0]),1);
        }
    }
}
