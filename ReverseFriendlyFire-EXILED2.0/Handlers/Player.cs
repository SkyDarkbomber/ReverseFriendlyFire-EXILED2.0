using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;


namespace ReverseFriendlyFire_EXILED.Handlers
{
    class Player
    {
        public static List<float> DamageList = new List<float>(); //make something to store total damage
        public void OnFriendlyFire( HurtingEventArgs ev)
        {
            
            
            if (ev.Attacker.Side == ev.Target.Side)
            {
                
                float Dmg = (ev.HitInformations.Amount);  //get hit amount for attacker               
                DamageList.Add(Dmg);    //add damage to list                

                float DmgList = DamageList.Sum();

                float RemainingDmg = DmgList - ReverseFriendlyFire.Instance.Config.MaxFriendlyFire;//
                ev.Attacker.Broadcast(duration: 5, message: "Warning: Reverse friendly fire is going to activate if you do "+ RemainingDmg +"more damage!");
               
         

            }

        }
        public void OnFriendlyFireActivate(HurtingEventArgs ev)
        {
            float DmgList = DamageList.Sum();
            float RemainingDmg = DmgList - ReverseFriendlyFire.Instance.Config.MaxFriendlyFire;

            if( RemainingDmg >= ReverseFriendlyFire.Instance.Config.MaxFriendlyFire)
            {
                ev.Attacker.Broadcast(duration: 15, message: "REVERSE FRIENDLY FIRE IS ACTIVE ANY DAMAGE YOU DONE TO A FRIENDLIES WILL BE DIRECTED AT YOU");
                if (ev.Attacker.Side == ev.Target.Side)
                {

                   
                    float Dmg = (ev.HitInformations.Amount);
                    ev.Attacker.Hurt(Dmg, ev.Attacker, DamageTypes.P90);
                }
            }


        }
    
      
    }
}
