#include "gps_nmea.h"

unsigned char gps_hrs[3]={};
unsigned char gps_mns[3]={};
unsigned char gps_scs[3]={};

volatile unsigned char gps_status1='-';

volatile unsigned char gps_satellites=0;
volatile unsigned char gps_quality=0;

volatile unsigned char gps_hour=0;
volatile unsigned char gps_min=0;
volatile unsigned char gps_sec=0;

char gps_location[64]={};
	
char gps_decode_gpgga(char* buffer)
{
	char h,m,s;
	volatile char* ptr=strtok(buffer,",");
	char buff[4];
	for (char i=1; i<8; i++)
	{
		ptr=strtok(NULL,",");
		if ((i==1)&&(ptr!=NULL))
		{
			buff[0]=ptr[0];buff[1]=ptr[1];buff[2]=0;	h=atoi(buff);
			buff[0]=ptr[2];buff[1]=ptr[3];buff[2]=0;	m=atoi(buff);
			buff[0]=ptr[4];buff[1]=ptr[5];buff[2]=0;	s=atoi(buff);
			
			gps_hrs[2]=gps_hrs[1];gps_hrs[1]=gps_hrs[0];gps_hrs[0]=h;
			gps_mns[2]=gps_mns[1];gps_mns[1]=gps_mns[0];gps_mns[0]=m;
			gps_scs[2]=gps_scs[1];gps_scs[1]=gps_scs[0];gps_scs[0]=s;
			
			if ((gps_hrs[0]==gps_hrs[1])&&
			(gps_hrs[0]==gps_hrs[2])&&
			(gps_mns[0]==gps_mns[1])&&
			(gps_mns[0]==gps_mns[2])/*&&
			(gps_scs[0]==gps_scs[1]+1)&&
			(gps_scs[0]==gps_scs[2]+2)*/)
			{
				buff[0]=ptr[7];buff[1]=ptr[8];buff[2]=ptr[9];buff[3]=0;	gps_msec=atoi(buff);
				gps_hour=h;	gps_min=m;	gps_sec=s;
			}else 
			{
				return 0;
			}
		}
		if ((i==6)&&(ptr!=NULL))
		{
			buff[0]=ptr[0];buff[1]=0;buff[2]=0;
			gps_quality=atoi(buff);
		}		
		if ((i==7)&&(ptr!=NULL))
		{
			buff[0]=ptr[0];buff[1]=ptr[1];buff[2]=0;
			gps_satellites=atoi(buff);
		}		
	}
	return 1;
}

char gps_decode_gprmc(char* buffer)
{
	char h,m,s;
	char* ptr=strtok(buffer,",");
	char buff[4];
	gps_status1='-';
	for (char i=1; i<8; i++)
	{
		ptr=strtok(NULL,",");
		if ((i==1)&&(ptr!=NULL))
		{
			buff[0]=ptr[0];buff[1]=ptr[1];buff[2]=0;	h=atoi(buff);
			buff[0]=ptr[2];buff[1]=ptr[3];buff[2]=0;	m=atoi(buff);
			buff[0]=ptr[4];buff[1]=ptr[5];buff[2]=0;	s=atoi(buff);
			
			gps_hrs[2]=gps_hrs[1];gps_hrs[1]=gps_hrs[0];gps_hrs[0]=h;
			gps_mns[2]=gps_mns[1];gps_mns[1]=gps_mns[0];gps_mns[0]=m;
			gps_scs[2]=gps_scs[1];gps_scs[1]=gps_scs[0];gps_scs[0]=s;
			
			if ((gps_hrs[0]==gps_hrs[1])&&
			(gps_hrs[0]==gps_hrs[2])&&
			(gps_mns[0]==gps_mns[1])&&
			(gps_mns[0]==gps_mns[2])/*&&
			(gps_scs[0]==gps_scs[1]+1)&&
			(gps_scs[0]==gps_scs[2]+2)*/)
			{
				buff[0]=ptr[7];buff[1]=ptr[8];buff[2]=ptr[9];buff[3]=0;	gps_msec=atoi(buff);
				gps_hour=h;	gps_min=m;	gps_sec=s;
			}else 
			{
				return 0;
			}
		}
		if ((i==2)&&(ptr!=NULL))
		{
			gps_status1=ptr[0];
		}
	}
	return 1;
}