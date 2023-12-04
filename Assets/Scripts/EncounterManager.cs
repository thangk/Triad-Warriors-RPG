using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.player.moving == true) {
            int encounter_chance = Random.Range(0, 100);

            if (SceneManager.GetActiveScene().name == "Whispering Woods")
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance <= 20)
                    {
                        //start Tree Guardians encounter

                        //EncounterArena.setmob("Tree Guardians");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else if (mob_chance > 20 || mob_chance <= 50)
                    {
                        //start Luminescent Slimes encounter

                        //EncounterArena.setmob("Luminescent Slimes");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Wandering Spirits encounter

                        //EncounterArena.setmob("Wandering Spirits");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Duskguard")  
            {
                // your in a town you shouldnt be encountering mobs by walking
            }

            if (SceneManager.GetActiveScene().name == "Peddlers Road")  
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance <= 25)
                    {
                        //start Hidden Caches encounter

                        //EncounterArena.setmob("Hidden Caches");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else if (mob_chance > 25 || mob_chance <= 40)
                    {
                        //start Wild Creatures encounter

                        //EncounterArena.setmob("Wild Creatures");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Highwaymen encounter

                        //EncounterArena.setmob("Highwaymen");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }
            
            if (SceneManager.GetActiveScene().name == "Bandit Hideout")
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance > 0 || mob_chance <= 50)
                    {
                        //start Bandit Thugs encounter

                        //EncounterArena.setmob("Bandit Thugs");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Bandit Traps encounter

                        //EncounterArena.setmob("Bandit Traps");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Al Masarah")
            {
                // your in a town you shouldnt be encountering mobs by walking
            }

            if (SceneManager.GetActiveScene().name == "Foreign Temple")
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance <= 50)
                    {
                        //start Sandstone Guardians

                        //EncounterArena.setmob("Sandstone Guardians");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Temple Traps

                        //EncounterArena.setmob("Temple Traps");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Secret Tunnel")
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance > 0 || mob_chance <= 50)
                    {
                        //start Spider encounter

                        //EncounterArena.setmob("Spider");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Bats encounter

                        //EncounterArena.setmob("Bats");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "Peddlers Road")
            {
                if (encounter_chance < 40) // 40 for static encounter chance
                {
                    //start encounter
                    int mob_chance = Random.Range(0, 100);

                    if (mob_chance <= 50)
                    {
                        //start Cultist Sentinels encounter

                        //EncounterArena.setmob("Cultist Sentinels");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                    else
                    {
                        //start Rune Guardians encounter

                        //EncounterArena.setmob("Rune Guardians");
                        //SceneTransitioner.transitionToScene("Encounter Arena");
                    }
                }
            }
        }   
    }
}
