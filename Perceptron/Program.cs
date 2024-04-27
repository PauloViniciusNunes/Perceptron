using System;
using System.Diagnostics;
public class Program{

    static decimal[] sum = {0.0m, 0.0m, 0.0m};
    static decimal[] errors = {0.0m, 0.0m, 0.0m};
    static decimal[] input = {1.0m, 0.5m, 1.3m};
    static decimal[] weight = {0.0m, 1.0m, 0.0m};
    static decimal[] output_desire = {1.0m, 0.0m, 1.0m};
    static decimal taxa_aprendizado = 0.1m;
    static decimal bias = 1.0m;
    static decimal[] bias_weight = {0.5m, 0.5m, 0.5m};
    static decimal[] prevision = {0.0m, 0.0m, 0.0m};
    
    private static void ActivationFunction(decimal[] parameter){
        for(int k = 0; k < parameter.Length; k++){
            if(sum[k] >= 0){
                parameter[k] = 1.0m;
            } else {
                parameter[k] = 0.0m;
            }
        }
    }

    private static void Main(string[] args){

        
        Console.WriteLine($"Parametros de Entrada: {input[0]}, {input[1]} e {input[2]}");
        int generations = 0;
        while(true){
            if(prevision[0] == output_desire[0] && prevision[1] == output_desire[1] && prevision[2] == output_desire[2]){
                Console.WriteLine($"O Programa aprendeu com o total de {generations} gerações!\n");
                Console.WriteLine($"DEMONSTRAÇÃO: OBTIDO/ESPERADO\n{prevision[0]}|{output_desire[0]}\n{prevision[1]}|{output_desire[1]}\n{prevision[2]}|{output_desire[2]}");
                break;
            } else{
                Console.WriteLine($"Saidas: {prevision[0]}, {prevision[1]} e {prevision[2]}\nSaidas Esperadas: {output_desire[0]}, {output_desire[1]} e {output_desire[2]}");
                /*Console.WriteLine($"Erros: {errors[0]}, {errors[1]}, {errors[2]}");
                Console.WriteLine($"Somas: {sum[0]}, {sum[1]}, {sum[2]}");*/
                generations += 1;
                for(int j = 0; j < sum.Length; j++){
                    sum[j] = (input[j] * weight[j]) + (bias * bias_weight[j]);
                }
                ActivationFunction(prevision);
                for(int i = 0; i < errors.Length; i++){
                    errors[i] = output_desire[i] - prevision[i];
                }
                for(int z = 0; z < weight.Length; z++){
                    if(!(errors[z] == 0)){
                        weight[z] += (taxa_aprendizado * input[z] * errors[z]);
                        bias_weight[z] = bias_weight[z] + (taxa_aprendizado * bias * errors[z]);
                    }
                }

                if(generations >= 100){
                    Console.WriteLine("O programa não conseguiu aprender :(");
                    break;
                }
            }
        }
    }
}