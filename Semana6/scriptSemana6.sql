/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     3/5/2021 14:17:41                            */
/*==============================================================*/


drop table if exists AUDITORIA;

drop table if exists DETALLE_INCIDENCIA;

drop table if exists DISTRIBUTIVOS;

drop table if exists ESTUDIANTES;

drop table if exists INCIDENCIAS;

drop table if exists NOVEDADES;

drop table if exists SEMANAS;

/*==============================================================*/
/* Table: AUDITORIA                                             */
/*==============================================================*/
create table AUDITORIA
(
   ID_AUDITORIA         int not null,
   FECHA_MODIFICACION   date,
   USUARIO              varchar(256),
   TIPO_MODIFICACION    varchar(800),
   primary key (ID_AUDITORIA)
);

/*==============================================================*/
/* Table: DETALLE_INCIDENCIA                                    */
/*==============================================================*/
create table DETALLE_INCIDENCIA
(
   ID_DETALLE_INCIDENCIA int not null,
   ID_INCIDENCIAS       int,
   ID_NOVEDADES         int,
   OBSERVACION          varchar(256),
   primary key (ID_DETALLE_INCIDENCIA)
);

/*==============================================================*/
/* Table: DISTRIBUTIVOS                                         */
/*==============================================================*/
create table DISTRIBUTIVOS
(
   ID_DISTRIBUTIVOS     int not null,
   primary key (ID_DISTRIBUTIVOS)
);

/*==============================================================*/
/* Table: ESTUDIANTES                                           */
/*==============================================================*/
create table ESTUDIANTES
(
   ID_ESTUDIANTES       int not null,
   primary key (ID_ESTUDIANTES)
);

/*==============================================================*/
/* Table: INCIDENCIAS                                           */
/*==============================================================*/
create table INCIDENCIAS
(
   ID_INCIDENCIAS       int not null,
   ID_ESTUDIANTES       int,
   ID_DISTRIBUTIVOS     int,
   ID_SEMANA            int,
   FECHA_INCIDENCIA     date,
   FECHA_REGISTRO       date,
   ESTADO_INCIDENCIA    int,
   ESTADO_REGISTRO      int,
   ESTADO_PROCESO       int,
   OBSERVACION          varchar(256),
   primary key (ID_INCIDENCIAS)
);

/*==============================================================*/
/* Table: NOVEDADES                                             */
/*==============================================================*/
create table NOVEDADES
(
   ID_NOVEDADES         int not null,
   NOMBRE               varchar(256) not null,
   DETALLE              varchar(256),
   ESTADO_INCIDENCIA    int,
   primary key (ID_NOVEDADES)
);

/*==============================================================*/
/* Table: SEMANAS                                               */
/*==============================================================*/
create table SEMANAS
(
   ID_SEMANA            int not null,
   NOMBRE               varchar(256),
   ESTADO               int,
   primary key (ID_SEMANA)
);

alter table DETALLE_INCIDENCIA add constraint FK_RELATIONSHIP_3 foreign key (ID_INCIDENCIAS)
      references INCIDENCIAS (ID_INCIDENCIAS) on delete restrict on update restrict;

alter table DETALLE_INCIDENCIA add constraint FK_RELATIONSHIP_4 foreign key (ID_NOVEDADES)
      references NOVEDADES (ID_NOVEDADES) on delete restrict on update restrict;

alter table INCIDENCIAS add constraint FK_RELATIONSHIP_1 foreign key (ID_DISTRIBUTIVOS)
      references DISTRIBUTIVOS (ID_DISTRIBUTIVOS) on delete restrict on update restrict;

alter table INCIDENCIAS add constraint FK_RELATIONSHIP_2 foreign key (ID_ESTUDIANTES)
      references ESTUDIANTES (ID_ESTUDIANTES) on delete restrict on update restrict;

alter table INCIDENCIAS add constraint FK_RELATIONSHIP_5 foreign key (ID_SEMANA)
      references SEMANAS (ID_SEMANA) on delete restrict on update restrict;

