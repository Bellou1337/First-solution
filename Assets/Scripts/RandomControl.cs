using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Animations;
using UnityEngine;

public class RandomControl : MonoBehaviour
{
    // перемещение игрока
    private static KeyCode[] player_control = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.Space };
    private static KeyCode[] skill_control = new KeyCode[] { KeyCode.R, KeyCode.T, KeyCode.F, KeyCode.G, KeyCode.V,  KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};
    private static System.Random random = new System.Random();

    public static ControlKeys get_rand_control_player()
    {
        ControlKeys control_keys = new ControlKeys();
        KeyCode[] rand_player_control = new KeyCode[control_keys.key_count];
        bool[] selected_player = new bool[player_control.Length];
        for (int i = 0; i < 5; i++)
        {
            int index;
            do
            {
                index = random.Next(player_control.Length);
            } while (selected_player[index]);

            rand_player_control[i] = player_control[index];
            selected_player[index] = true;
        }

        
        bool[] selected_skills = new bool[skill_control.Length];
        for (int i = 5; i < 9; i++)
        {
            int index;
            do
            {
                index = random.Next(skill_control.Length);
            } while (selected_skills[index]);

            rand_player_control[i] = skill_control[index];
            selected_skills[index] = true;
        }

        control_keys.move_forward = rand_player_control[0];
        control_keys.move_backward = rand_player_control[1];
        control_keys.move_right = rand_player_control[2];
        control_keys.move_left = rand_player_control[3];
        control_keys.jump = rand_player_control[4];

        control_keys.skill1 = rand_player_control[5];
        control_keys.skill2 = rand_player_control[6];
        control_keys.skill3 = rand_player_control[7];
        control_keys.skill4 = rand_player_control[8];

        return control_keys;
    }
}
