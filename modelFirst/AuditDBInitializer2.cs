using modelFirst.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst
{
    class AuditDBInitializer2 : SqliteDropCreateDatabaseWhenModelChanges<AuditContext>
    {
        public AuditDBInitializer2(DbModelBuilder modelBuilder) : base(modelBuilder)
        {

        }

        protected override void Seed(AuditContext context)
        {
            base.Seed(context);

            Category physic = new Category();
            physic.Id = 1;
            physic.Name = "Sécurité Pysique";
            context.Categories.Add(physic);

            Category reseau = new Category();
            reseau.Id = 2;
            reseau.Name = "Sécurité Réseau";
            context.Categories.Add(reseau);

            Category strategie = new Category();
            reseau.Id = 3;
            reseau.Name = "Strategie interne";
            context.Categories.Add(strategie);

            Question q1 = new Question();
            q1.Id = 1;
            q1.Intitled = "Le périmètre du site (bâtiments) est-il bien défini par des murs et des barrières de construction solide?";
            q1.Details = "Details ";
            q1.Coefficient = 3;
            q1.Scale = 10;
            q1.Recommandation = "Vous devez définir un périmètre de sécurité pour vos installations et le sécuriser par des murs et barrières.";
            q1.Risk = "Risk ";
            q1.CreatedAt = DateTime.Now;
            q1.UpdateAt = DateTime.Now;
            q1.Category = physic;
            context.Questions.Add(q1);

            Question q2 = new Question();
            q2.Id = 2;
            q2.Intitled = "Les portes et fenêtres sont-elles verrouillées lorsqu'elles ne sont pas sous surveillance?";
            q2.Details = "Details ";
            q2.Coefficient = 4;
            q2.Scale = 10;
            q2.Recommandation = "Vous devez rajouter des verrous aux portes et fenêtres; et des barreaux externes aux fenêtres.";
            q2.Risk = "Risk ";
            q2.CreatedAt = DateTime.Now;
            q2.UpdateAt = DateTime.Now;
            q2.Category = physic;
            context.Questions.Add(q2);

            Question q3 = new Question();
            q3.Id = 3;
            q3.Intitled = "Un système de détection d'intrusions est-il en place?";
            q3.Details = "Details ";
            q3.Coefficient = 3;
            q3.Scale = 10;
            q3.Recommandation = "Vous devez être en mesure de détecter une intrusion si les portes sont voilées";
            q3.Risk = "Risk ";
            q3.CreatedAt = DateTime.Now;
            q3.UpdateAt = DateTime.Now;
            q3.Category = physic;
            context.Questions.Add(q3);

            Question q4 = new Question();
            q4.Id = 4;
            q4.Intitled = "Existe-il un réception permettant de contrôler l'accès physique aux bâtiments?";
            q4.Details = "Details ";
            q4.Coefficient = 4;
            q4.Scale = 10;
            q4.Recommandation = "Vous devez mettre en place la réception pour contrôler l'accès.";
            q4.Risk = "Risk ";
            q4.CreatedAt = DateTime.Now;
            q4.UpdateAt = DateTime.Now;
            q4.Category = physic;
            context.Questions.Add(q4);

            Question q5 = new Question();
            q5.Id = 5;
            q5.Intitled = "Existe-il des portes coupe-feu conformes aux normes internationales?";
            q5.Details = "Details ";
            q5.Coefficient = 5;
            q5.Scale = 10;
            q5.Recommandation = "Il est impératif d'avoir des portes coupe-feu dans les cas d'incendies.";
            q5.Risk = "Risk ";
            q5.CreatedAt = DateTime.Now;
            q5.UpdateAt = DateTime.Now;
            q5.Category = physic;
            context.Questions.Add(q5);

            Question q6 = new Question();
            q6.Id = 6;
            q6.Intitled = "Les zones non occupées sont-elles sous surveillance?";
            q6.Details = "Details ";
            q6.Coefficient = 2;
            q6.Scale = 10;
            q6.Recommandation = "toute zone situé à l'intérieur du périmètre définit doit être sous surveillance.";
            q6.Risk = "Risk ";
            q6.CreatedAt = DateTime.Now;
            q6.UpdateAt = DateTime.Now;
            q6.Category = physic;
            context.Questions.Add(q6);

            Question q7 = new Question();
            q7.Id = 7;
            q7.Intitled = "Les zones sensibles (salle des machines) ont-elles un accès retreint (code PIN, badge, ...)?";
            q7.Details = "Details ";
            q7.Coefficient = 5;
            q7.Scale = 10;
            q7.Recommandation = "Vous devez restreinte l'accès aux zones sensibles uniquement aux personnels autorisés.";
            q7.Risk = "Risk ";
            q7.CreatedAt = DateTime.Now;
            q7.UpdateAt = DateTime.Now;
            q7.Category = physic;
            context.Questions.Add(q7);

            Question q8 = new Question();
            q8.Id = 8;
            q8.Intitled = "Les dates d'arrivée et de départ des visiteurs sont-elles enregistrées?";
            q8.Details = "Details ";
            q8.Coefficient = 3;
            q8.Scale = 10;
            q8.Recommandation = "Vous devez garder des traces de toutes les personnes ayant eu accès à vos installation.";
            q8.Risk = "Risk ";
            q8.CreatedAt = DateTime.Now;
            q8.UpdateAt = DateTime.Now;
            q8.Category = physic;
            context.Questions.Add(q8);

            Question q9 = new Question();
            q9.Id = 9;
            q9.Intitled = "Les zones d'accès sont-elles restreintes pour les visiteurs?";
            q9.Details = "Details ";
            q9.Coefficient = 3;
            q9.Scale = 10;
            q9.Recommandation = "Vous ne devez pas laisser les visiteurs avoir accès aux zones sensibles (RD, ...).";
            q9.Risk = "Risk ";
            q9.CreatedAt = DateTime.Now;
            q9.UpdateAt = DateTime.Now;
            q9.Category = physic;
            context.Questions.Add(q9);

            Question q10 = new Question();
            q10.Id = 10;
            q10.Intitled = "Les visiteurs sont-ils escortés tout au long de leur visite?";
            q10.Details = "Details ";
            q10.Coefficient = 3;
            q10.Scale = 10;
            q10.Recommandation = "Vous ne devez pas laisser vos visiteurs seuls, car vous ne connaissez pas toujours leurs intentions. Ils doivent être escortés pendant la visite.";
            q10.Risk = "Risk ";
            q10.CreatedAt = DateTime.Now;
            q10.UpdateAt = DateTime.Now;
            q10.Category = physic;
            context.Questions.Add(q10);

            Question q11 = new Question();
            q11.Id = 11;
            q11.Intitled = "Employés et visiteurs portent-ils un signe permettant de les identifier (badge...)?";
            q11.Details = "Details ";
            q11.Coefficient = 2;
            q11.Scale = 10;
            q11.Recommandation = "Vous devez être en mesure d'identifier rapidement toute personne circulant à l'intérieur du site.";
            q11.Risk = "Risk ";
            q11.CreatedAt = DateTime.Now;
            q11.UpdateAt = DateTime.Now;
            q11.Category = physic;
            context.Questions.Add(q11);

            Question q12 = new Question();
            q12.Id = 12;
            q12.Intitled = "Les droits d'accès aux zones sécurisées sont-ils revus et mis à jour régulièrement?";
            q12.Details = "Details ";
            q12.Coefficient = 4;
            q12.Scale = 10;
            q12.Recommandation = "Vous devez toujours être sûr que seuls les personnes autorisés ont reçu les droits d'accès.";
            q12.Risk = "Risk ";
            q12.CreatedAt = DateTime.Now;
            q12.UpdateAt = DateTime.Now;
            q12.Category = physic;
            context.Questions.Add(q12);

            Question q13 = new Question();
            q13.Id = 13;
            q13.Intitled = "Les matériaux dangereux et combustibles sont-ils entreposés avec une distance de sécurité (loin) des zones sécurisées?";
            q13.Details = "Details ";
            q13.Coefficient = 4;
            q13.Scale = 10;
            q13.Recommandation = "Il est préférable de prévoir un entrepôt sécurisé qui est loin des zones sécurisées.";
            q13.Risk = "Risk ";
            q13.CreatedAt = DateTime.Now;
            q13.UpdateAt = DateTime.Now;
            q13.Category = physic;
            context.Questions.Add(q13);

            Question q14 = new Question();
            q14.Id = 14;
            q14.Intitled = "Les équipement de secours sont-ils gardés avec une distance de sécurité (loin) du site principal?";
            q14.Details = "Details ";
            q14.Coefficient = 5;
            q14.Scale = 10;
            q14.Recommandation = "Assurez-vous qu'en cas de dommage le matériel de secours ne soit pas également endommagé.";
            q14.Risk = "Risk ";
            q14.CreatedAt = DateTime.Now;
            q14.UpdateAt = DateTime.Now;
            q14.Category = physic;
            context.Questions.Add(q14);

            Question q15 = new Question();
            q15.Id = 15;
            q15.Intitled = "Les appareils photographique et sonore sont-ils contrôlés?";
            q15.Details = "Details ";
            q15.Coefficient = 4;
            q15.Scale = 10;
            q15.Recommandation = "Vous devez prévenir toutes fuites d'informations qui peuvent se faire par l'utilisation de ces appareils.";
            q15.Risk = "Risk ";
            q15.CreatedAt = DateTime.Now;
            q15.UpdateAt = DateTime.Now;
            q15.Category = physic;
            context.Questions.Add(q15);

            Question q16 = new Question();
            q16.Id = 16;
            q16.Intitled = "Tout matériel entrant sur le site est-il enregistré et contrôlé?";
            q16.Details = "Details ";
            q16.Coefficient = 4;
            q16.Scale = 10;
            q16.Recommandation = "Vous devez vérifier que tout le matériel est conforme et ne constitue pas un risque pour la sécurité.";
            q16.Risk = "Risk ";
            q16.CreatedAt = DateTime.Now;
            q16.UpdateAt = DateTime.Now;
            q16.Category = physic;
            context.Questions.Add(q16);

            Question q17 = new Question();
            q17.Id = 17;
            q17.Intitled = "Les zones de livraison restreignent-elles l'accès aux autres parties du bâtiments aux fournisseurs?";
            q17.Details = "Details ";
            q17.Coefficient = 3;
            q17.Scale = 10;
            q17.Recommandation = "Assurez-vous que vos fournisseurs ne puissent pas avoir accès à des zones sécurisées et sensibles.";
            q17.Risk = "Risk ";
            q17.CreatedAt = DateTime.Now;
            q17.UpdateAt = DateTime.Now;
            q17.Category = physic;
            context.Questions.Add(q17);

            Question q18 = new Question();
            q18.Id = 18;
            q18.Intitled = "Les conditions de l'environnement (température, humidité, ...) sont-elles contrôlées?";
            q18.Details = "Details ";
            q18.Coefficient = 4;
            q18.Scale = 10;
            q18.Recommandation = "Vous devez toujours garder l'environnement dans les conditions qui ne détériorent pas vos installations.";
            q18.Risk = "Risk ";
            q18.CreatedAt = DateTime.Now;
            q18.UpdateAt = DateTime.Now;
            q18.Category = physic;
            context.Questions.Add(q18);

            Question q19 = new Question();
            q19.Id = 19;
            q19.Intitled = "La maintenance des équipement est-elle effectuée selon les recommandations du constructeur?";
            q19.Details = "Details ";
            q19.Coefficient = 4;
            q19.Scale = 10;
            q19.Recommandation = "Vous devez impérativement suivre les recommandations du constructeur afin d'éviter tous les risques.";
            q19.Risk = "Risk ";
            q19.CreatedAt = DateTime.Now;
            q19.UpdateAt = DateTime.Now;
            q19.Category = physic;
            context.Questions.Add(q19);

            Question q20 = new Question();
            q20.Id = 20;
            q20.Intitled = "La sortie de matériel et logiciel du site est-elle contrôlée?";
            q20.Details = "Details ";
            q20.Coefficient = 5;
            q20.Scale = 10;
            q20.Recommandation = "Vous devez éviter toute fuite qui pourrait être causée par l'un de vos employés.";
            q20.Risk = "Risk ";
            q20.CreatedAt = DateTime.Now;
            q20.UpdateAt = DateTime.Now;
            q20.Category = physic;
            context.Questions.Add(q20);

            Question q21 = new Question();
            q21.Id = 21;
            q21.Intitled = "Les zones sécurisées vacantes sont-elles verrouillées?";
            q21.Details = "Details ";
            q21.Coefficient = 3;
            q21.Scale = 10;
            q21.Recommandation = "Vous ne devez jamais laissée une zone sécurisée sans surveillance, même si il n'y pas d'actitvités dans cette zone.";
            q21.Risk = "Risk ";
            q21.CreatedAt = DateTime.Now;
            q21.UpdateAt = DateTime.Now;
            q21.Category = physic;
            context.Questions.Add(q21);

            Question q22 = new Question();
            q22.Id = 22;
            q22.Intitled = "Les câbles électriques et de réseaux sont-ils proches les uns les autres?";
            q22.Details = "Details ";
            q22.Coefficient = 3;
            q22.Scale = 10;
            q22.Recommandation = "Vous ne devez éloigner les câbles réseaux des câbles électriques pour éviter les interférence";
            q22.Risk = "Risk ";
            q22.CreatedAt = DateTime.Now;
            q22.UpdateAt = DateTime.Now;
            q22.Category = physic;
            context.Questions.Add(q22);

            Question q23 = new Question();
            q23.Id = 23;
            q23.Intitled = "Avez-vous une politique d'utilisation des réseaux et services réseaux?";
            q23.Details = "Details ";
            q23.Coefficient = 4;
            q23.Scale = 10;
            q23.Recommandation = "Vous devez mettre en place une politique qui: définit clairement les résaeux et services réseaux accessibles et par qui; ainsi que les stratégies d'accès.";
            q23.Risk = "Risk ";
            q23.CreatedAt = DateTime.Now;
            q23.UpdateAt = DateTime.Now;
            q23.Category = reseau;
            context.Questions.Add(q23);

            Question q24 = new Question();
            q24.Id = 24;
            q24.Intitled = "Les connexions distantes des utilisateurs sont-elles sécurisées?";
            q24.Details = "Details ";
            q24.Coefficient = 5;
            q24.Scale = 10;
            q24.Recommandation = "Vous ne devez autorisées que des connexions distantes sécurisées (utilisation de VPN ...).";
            q24.Risk = "Risk ";
            q24.CreatedAt = DateTime.Now;
            q24.UpdateAt = DateTime.Now;
            q24.Category = reseau;
            context.Questions.Add(q24);

            Question q25 = new Question();
            q25.Id = 25;
            q25.Intitled = "Avez-vous une segmentation du réseau?";
            q25.Details = "Details ";
            q25.Coefficient = 4;
            q25.Scale = 10;
            q25.Recommandation = "Vous devez implémenter une stratégie de segmentation de réseau pour une meilleure gestion des autorisations d'accès.";
            q25.Risk = "Risk ";
            q25.CreatedAt = DateTime.Now;
            q25.UpdateAt = DateTime.Now;
            q25.Category = reseau;
            context.Questions.Add(q25);

            Question q26 = new Question();
            q26.Id = 26;
            q26.Intitled = "Utilisez-vous une stratégie d'authentification du matériel sur le réseau?";
            q26.Details = "Details ";
            q26.Coefficient = 3;
            q26.Scale = 10;
            q26.Recommandation = "Vous devez impémenter l'authentification du matériel pour limiter l'accès du matériel sur des segments précis du réseau.";
            q26.Risk = "Risk ";
            q26.CreatedAt = DateTime.Now;
            q26.UpdateAt = DateTime.Now;
            q26.Category = reseau;
            context.Questions.Add(q26);

            Question q27 = new Question();
            q27.Id = 27;
            q27.Intitled = "Les ports de diagnostic distant du matériel sont-ils controlés?";
            q27.Details = "Details ";
            q27.Coefficient = 4;
            q27.Scale = 10;
            q27.Recommandation = "Vous devez vous assurer que les ports de diagnostic distant sont sécurisés ou désactivés.";
            q27.Risk = "Risk ";
            q27.CreatedAt = DateTime.Now;
            q27.UpdateAt = DateTime.Now;
            q27.Category = reseau;
            context.Questions.Add(q27);

            Question q28 = new Question();
            q28.Id = 28;
            q28.Intitled = "Les droits d'accès au réseau sont-ils mis à jour régulièrement?";
            q28.Details = "Details ";
            q28.Coefficient = 3;
            q28.Scale = 10;
            q28.Recommandation = "Vous devez régulièrement mettre à jour les droits d'accès.";
            q28.Risk = "Risk ";
            q28.CreatedAt = DateTime.Now;
            q28.UpdateAt = DateTime.Now;
            q28.Category = reseau;
            context.Questions.Add(q28);

            Question q29 = new Question();
            q29.Id = 29;
            q29.Intitled = "Le routage au sein du réseau est-il controlé?";
            q29.Details = "Details ";
            q29.Coefficient = 5;
            q29.Scale = 10;
            q29.Recommandation = "Vous devez impérativement controlé le routage au sein du réseau, Afin d'assurer que la stratégie de segmentation de réseau est respectée. Ceci est d'autant plus important si votre réseau s'étend avec des réseaux d'autres organisation (FAI, ...).";
            q29.Risk = "Risk ";
            q29.CreatedAt = DateTime.Now;
            q29.UpdateAt = DateTime.Now;
            q29.Category = reseau;
            context.Questions.Add(q29);

            Question q30 = new Question();
            q30.Id = 30;
            q30.Intitled = "Le matérie réseau est-il protégé physiquement?";
            q30.Details = "Details ";
            q30.Coefficient = 3;
            q30.Scale = 10;
            q30.Recommandation = "Inclure dans la politique de sécurité physique la protection du matériel réseau.";
            q30.Risk = "Risk ";
            q30.CreatedAt = DateTime.Now;
            q30.UpdateAt = DateTime.Now;
            q30.Category = reseau;
            context.Questions.Add(q30);

            Question q31 = new Question();
            q31.Id = 31;
            q31.Intitled = "Utilisez-vous des antivirus sur vos ordinateurs?";
            q31.Details = "Details ";
            q31.Coefficient = 3;
            q31.Scale = 10;
            q31.Recommandation = "Vous devez installer des antivirus sur vos ordinateurs.";
            q31.Risk = "Risk ";
            q31.CreatedAt = DateTime.Now;
            q31.UpdateAt = DateTime.Now;
            q31.Category = strategie;
            context.Questions.Add(q31);

            Question q32 = new Question();
            q32.Id = 32;
            q32.Intitled = "Mettez-vous régulièrement vos antivirus à jour?";
            q32.Details = "Details ";
            q32.Coefficient = 3;
            q32.Scale = 10;
            q32.Recommandation = "Il faut régulièrement mettre vos antivirus à jour et faire de scans de vos ordinateurs.";
            q32.Risk = "Risk ";
            q32.CreatedAt = DateTime.Now;
            q32.UpdateAt = DateTime.Now;
            q32.Category = strategie;
            context.Questions.Add(q32);

            Question q33 = new Question();
            q33.Id = 33;
            q33.Intitled = "Avez-vous une politique sur la transmission et le traitement de l'information?";
            q33.Details = "Details ";
            q33.Coefficient = 4;
            q33.Scale = 10;
            q33.Recommandation = "Une politique de transmission et de traitement de l'information doit être définit.";
            q33.Risk = "Risk ";
            q33.CreatedAt = DateTime.Now;
            q33.UpdateAt = DateTime.Now;
            q33.Category = strategie;
            context.Questions.Add(q33);

            Question q34 = new Question();
            q34.Id = 34;
            q34.Intitled = "Existe-t-il une séparation des tâches?";
            q34.Details = "Details ";
            q34.Coefficient = 3;
            q34.Scale = 10;
            q34.Recommandation = "Il est important d'implémenter une séparation afin que les utilisateurs n'effectuent que les tâches auxquelles ils sont autorisés.";
            q34.Risk = "Risk ";
            q34.CreatedAt = DateTime.Now;
            q34.UpdateAt = DateTime.Now;
            q34.Category = strategie;
            context.Questions.Add(q34);

            Question q35 = new Question();
            q35.Id = 35;
            q35.Intitled = "Les changements apportés au système de traitement de l'information sont-ils controlés?";
            q35.Details = "Details ";
            q35.Coefficient = 5;
            q35.Scale = 10;
            q35.Recommandation = "Les changements sur le système de traitement doivent être soumis à un contrôle strict (planification, test, procédure de secours en cas d'échec, communication avec les utilisateurs, ...).";
            q35.Risk = "Risk ";
            q35.CreatedAt = DateTime.Now;
            q35.UpdateAt = DateTime.Now;
            q35.Category = strategie;
            context.Questions.Add(q35);

            Question q36 = new Question();
            q36.Id = 36;
            q36.Intitled = "Dans le cas d'une prestation de service, convenez-vous à l'avance des conditions de sécurité avec l'organisation tiers?";
            q36.Details = "Details ";
            q36.Coefficient = 4;
            q36.Scale = 10;
            q36.Recommandation = "Vous devez à l'avance définir les conditions de sécurité entre votre organisation et l'organisation tiers avant toute prestation.";
            q36.Risk = "Risk ";
            q36.CreatedAt = DateTime.Now;
            q36.UpdateAt = DateTime.Now;
            q36.Category = strategie;
            context.Questions.Add(q36);

            Question q37 = new Question();
            q37.Id = 37;
            q37.Intitled = "Effectuer vous une surveillance des services prestés?";
            q37.Details = "Details ";
            q37.Coefficient = 3;
            q37.Scale = 10;
            q37.Recommandation = "Vous devez faire un suivi de ces services pour vous assurer qu'ils respectent bien les accords de sécurité.";
            q37.Risk = "Risk ";
            q37.CreatedAt = DateTime.Now;
            q37.UpdateAt = DateTime.Now;
            q37.Category = strategie;
            context.Questions.Add(q37);

            Question q38 = new Question();
            q38.Id = 38;
            q38.Intitled = "La surveillance de l'utilisation des ressources (matériel et logiciel) est-elle effectuée?";
            q38.Details = "Details ";
            q38.Coefficient = 3;
            q38.Scale = 10;
            q38.Recommandation = "Vous devez surveillez l'utilisation de vos ressources afin de planifier leur maintenance ou évolution.";
            q38.Risk = "Risk ";
            q38.CreatedAt = DateTime.Now;
            q38.UpdateAt = DateTime.Now;
            q38.Category = strategie;
            context.Questions.Add(q38);

            Question q39 = new Question();
            q39.Id = 39;
            q39.Intitled = "Avez-vous une politique qui régit l'acquisition de fichiers et documents à  partir des réseaux externes et des médias(USB, CD, ...)?";
            q39.Details = "Details ";
            q39.Coefficient = 3;
            q39.Scale = 10;
            q39.Recommandation = "Vous devez définir des règles pour empêcher l'introduction de logiciels malveillants dans le système.";
            q39.Risk = "Risk ";
            q39.CreatedAt = DateTime.Now;
            q39.UpdateAt = DateTime.Now;
            q39.Category = strategie;
            context.Questions.Add(q39);

            Question q40 = new Question();
            q40.Id = 40;
            q40.Intitled = "Avez une politique qui definit la manière dont les sauvegardes d'infromations sont effectuées?";
            q40.Details = "Details ";
            q40.Coefficient = 4;
            q40.Scale = 10;
            q40.Recommandation = "IL vous est nécessaire de définir comment seront effectuées les sauvegardes (intervale entre les sauvegardes, support des sauvegardes, lieu de sauvegarde, ...).";
            q40.Risk = "Risk ";
            q40.CreatedAt = DateTime.Now;
            q40.UpdateAt = DateTime.Now;
            q40.Category = strategie;
            context.Questions.Add(q40);

            Question q41 = new Question();
            q41.Id = 41;
            q41.Intitled = "Avez-vous une procédure de destruction des supports qui ne sont plus utilisés (Disques durs, clés USB, CD, ...)?";
            q41.Details = "Details ";
            q41.Coefficient = 4;
            q41.Scale = 10;
            q41.Recommandation = "Il faut mettre en place une procédure sécurisé pour la destruction de supports (exp: incinération) pour éviter les fuites d'informations.";
            q41.Risk = "Risk ";
            q41.CreatedAt = DateTime.Now;
            q41.UpdateAt = DateTime.Now;
            q41.Category = strategie;
            context.Questions.Add(q41);

            Question q42 = new Question();
            q42.Id = 42;
            q42.Intitled = "La documentattion de votre système est-elle sécurisée?";
            q42.Details = "Details ";
            q42.Coefficient = 5;
            q42.Scale = 10;
            q42.Recommandation = "L'accès à la documentation doit être réduite au minimun pour ne pas fournir des informations pouvant le compromettre.";
            q42.Risk = "Risk ";
            q42.CreatedAt = DateTime.Now;
            q42.UpdateAt = DateTime.Now;
            q42.Category = strategie;
            context.Questions.Add(q42);

            Question q43 = new Question();
            q43.Id = 43;
            q43.Intitled = "Les informations que vous rendez publiques sont-elles sécurisées?";
            q43.Details = "Details ";
            q43.Coefficient = 3;
            q43.Scale = 10;
            q43.Recommandation = "Les informations rendues puliques doivent être sécurisées afin de préserver leur intégrité.";
            q43.Risk = "Risk ";
            q43.CreatedAt = DateTime.Now;
            q43.UpdateAt = DateTime.Now;
            q43.Category = strategie;
            context.Questions.Add(q43);

            Question q44 = new Question();
            q44.Id = 44;
            q44.Intitled = "Avez vous une stratégie de journalisation fonctionnelle?";
            q44.Details = "Details ";
            q44.Coefficient = 5;
            q44.Scale = 10;
            q44.Recommandation = "Il est impératif de garder les traces de toutes les opérations qui sont effectués au quotidien.";
            q44.Risk = "Risk ";
            q44.CreatedAt = DateTime.Now;
            q44.UpdateAt = DateTime.Now;
            q44.Category = strategie;
            context.Questions.Add(q44);

            Question q45 = new Question();
            q45.Id = 45;
            q45.Intitled = "Vos fichiers de journalisation sont-ils protégés?";
            q45.Details = "Details ";
            q45.Coefficient = 5;
            q45.Scale = 10;
            q45.Recommandation = "Les fichiers journaux doivent être protégés contre la falsification et les accès non autorisés.";
            q45.Risk = "Risk ";
            q45.CreatedAt = DateTime.Now;
            q45.UpdateAt = DateTime.Now;
            q45.Category = strategie;
            context.Questions.Add(q45);

            Auditer auditer = new Auditer()
            {
                Id = 1,
                FirstName = "Auditer 1",
                LastName = "Of Excellecia Audit ",
                Email = "auditer1@excellenciaudit.ma",
                PhoneNumber = "+212 6 33 22 55 1",
                Password = BCrypt.Net.BCrypt.HashPassword("123456789", BCrypt.Net.BCrypt.GenerateSalt(), false, BCrypt.Net.HashType.SHA256),
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now

            };

            context.Auditers.Add(auditer);

            Audit audit = new Audit()
            {
                Id = 1,
                Name = "Audit 1",
                AuditedCompanyName = "Company 1",
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            audit.Auditer = auditer;
            context.Audits.Add(audit);

            context.SaveChanges();
        }
        
    }
}
