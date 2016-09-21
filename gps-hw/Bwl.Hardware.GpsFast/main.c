#include "board/board.h"
#include "libs/bwl_uart.h"
#include "libs/strings.h"
#include "gps_nmea.h"
#include "gps_ml8088.h"

void uart_receive()
{
	if (uart_receive_line(1)>0)
	{
		uart_send_line(0,uart_receive_buffer_1);
	}
	
	if (uart_receive_line(0)>0)
	{
		if (strstr(uart_receive_buffer_0,"##")!=0)
		{
			if (strstr(uart_receive_buffer_0,"##MISCGPSCOMMAND")!=0)
			{
				char buffer[64];
				for (byte i=0; i<32; i++)
				{
					buffer[i]=uart_receive_buffer_0[i+16];
				}
				uart_send_line(1,"");
				uart_send_line(1,buffer);
			}
			if (strstr(uart_receive_buffer_0,"##MISCREBOOT")!=0)
			{
				wdt_enable(WDTO_500MS); while(1);
			}
			if (strstr(uart_receive_buffer_0,"##MISCGETINF")!=0)
			{
				uart_send_line(0,"");
				uart_send_string(0,"##DEVINF ");
				uart_send_string(0,"BwlGpsFast1.0");
				uart_send_string(0,__DATE__);
				uart_send(0,' ');
				uart_send_string(0,__TIME__);
				uart_send_line(0,"");
			}
		}
	}
}

void usb_init()
{
	uart_init_withdivider(0,25); //12 for 38400 on 16Mhz
}

int main(void)
{
	wdt_enable(WDTO_8S);
	DDRA=0; DDRB=0; DDRC=0; DDRD=0; PORTA=0; PORTB=0; PORTC=0; PORTD=0;
	uart_disable(0);uart_disable(1);
	wdt_reset();
	var_delay_ms(200);
	usb_init();
	gps_ml8088_init_gprmc_10hz();
	while(1)
	{
		uart_receive();
		wdt_reset();
	}
}