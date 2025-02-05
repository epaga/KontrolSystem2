# ksp::ui



## Types


### Align

Alignment of the element in off direction (horizontal for vertical container and vice versa)

#### Methods

##### to_string

```rust
align.to_string ( ) -> string
```

String representation of the number

### AlignConstants



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
Center | [ksp::up::Align](/reference/ksp/up.md#align) | R/O | Align the element to the center of the container.
End | [ksp::up::Align](/reference/ksp/up.md#align) | R/O | Align the element to end of container (right/bottom).
Start | [ksp::up::Align](/reference/ksp/up.md#align) | R/O | Align the element to start of container (left/top).
Stretch | [ksp::up::Align](/reference/ksp/up.md#align) | R/O | Strech the element to full size of container

#### Methods

##### from_string

```rust
alignconstants.from_string ( value : string ) -> Option<ksp::up::Align>
```

Parse from string

### Button



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
font_size | float | R/W | 
label | string | R/W | 

#### Methods

##### on_click

```rust
button.on_click ( onClick : sync fn() -> Unit ) -> Unit
```



### Canvas



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
height | float | R/O | 
min_size | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
width | float | R/O | 

#### Methods

##### add_line

```rust
canvas.add_line ( points : ksp::math::Vec2[],
                  strokeColor : ksp::console::RgbaColor,
                  closed : bool,
                  thickness : float ) -> ksp::ui::Line2D
```



##### add_pixel_line

```rust
canvas.add_pixel_line ( points : ksp::math::Vec2[],
                        strokeColor : ksp::console::RgbaColor,
                        closed : bool ) -> ksp::ui::PixelLine2D
```



##### add_polygon

```rust
canvas.add_polygon ( points : ksp::math::Vec2[],
                     fillColor : ksp::console::RgbaColor ) -> ksp::ui::Polygon2D
```



##### add_rect

```rust
canvas.add_rect ( point1 : ksp::math::Vec2,
                  point2 : ksp::math::Vec2,
                  fillColor : ksp::console::RgbaColor ) -> ksp::ui::Rect2D
```



##### add_rotate

```rust
canvas.add_rotate ( degrees : float ) -> ksp::ui::Rotate2D
```



##### add_scale

```rust
canvas.add_scale ( scale : ksp::math::Vec2 ) -> ksp::ui::Scale2D
```



##### add_text

```rust
canvas.add_text ( position : ksp::math::Vec2,
                  text : string,
                  fontSize : float,
                  color : ksp::console::RgbaColor,
                  degrees : float,
                  pivot : ksp::math::Vec2 ) -> ksp::ui::Text2D
```



##### add_translate

```rust
canvas.add_translate ( translate : ksp::math::Vec2 ) -> ksp::ui::Translate2D
```



##### add_value_raster

```rust
canvas.add_value_raster ( point1 : ksp::math::Vec2,
                          point2 : ksp::math::Vec2,
                          values : float[],
                          width : int,
                          height : int,
                          gradientWrapper : ksp::ui::Gradient ) -> ksp::ui::ValueRaster2D
```



##### clear

```rust
canvas.clear ( ) -> Unit
```



### Container



#### Methods

##### add_button

```rust
container.add_button ( label : string,
                       align : ksp::up::Align,
                       stretch : float ) -> ksp::ui::Button
```



##### add_canvas

```rust
container.add_canvas ( minWidth : float,
                       minHeight : float,
                       align : ksp::up::Align,
                       stretch : float ) -> ksp::ui::Canvas
```



##### add_float_input

```rust
container.add_float_input ( align : ksp::up::Align,
                            stretch : float ) -> ksp::ui::FloatInputField
```



##### add_horizontal

```rust
container.add_horizontal ( gap : float,
                           align : ksp::up::Align,
                           stretch : float ) -> ksp::ui::Container
```



##### add_horizontal_panel

```rust
container.add_horizontal_panel ( gap : float,
                                 align : ksp::up::Align,
                                 stretch : float ) -> ksp::ui::Container
```



##### add_horizontal_slider

```rust
container.add_horizontal_slider ( min : float,
                                  max : float,
                                  align : ksp::up::Align,
                                  stretch : float ) -> ksp::ui::Slider
```



##### add_int_input

```rust
container.add_int_input ( align : ksp::up::Align,
                          stretch : float ) -> ksp::ui::IntInputField
```



##### add_label

```rust
container.add_label ( label : string,
                      align : ksp::up::Align,
                      stretch : float ) -> ksp::ui::Label
```



##### add_string_input

```rust
container.add_string_input ( align : ksp::up::Align,
                             stretch : float ) -> ksp::ui::StringInputField
```



##### add_toggle

```rust
container.add_toggle ( label : string,
                       align : ksp::up::Align,
                       stretch : float ) -> ksp::ui::Toggle
```



##### add_vertical

```rust
container.add_vertical ( gap : float,
                         align : ksp::up::Align,
                         stretch : float ) -> ksp::ui::Container
```



##### add_vertical_panel

```rust
container.add_vertical_panel ( gap : float,
                               align : ksp::up::Align,
                               stretch : float ) -> ksp::ui::Container
```



### FloatInputField



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
font_size | float | R/W | 
value | float | R/W | 

#### Methods

##### bind

```rust
floatinputfield.bind ( boundValue : Cell<T> ) -> ksp::ui::FloatInputField
```



##### on_change

```rust
floatinputfield.on_change ( onChange : sync fn(float) -> Unit ) -> Unit
```



### Gradient



#### Methods

##### add_color

```rust
gradient.add_color ( value : float,
                     color : ksp::console::RgbaColor ) -> bool
```



### IntInputField



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
font_size | float | R/W | 
value | int | R/W | 

#### Methods

##### bind

```rust
intinputfield.bind ( boundValue : Cell<T> ) -> ksp::ui::IntInputField
```



##### on_change

```rust
intinputfield.on_change ( onChange : sync fn(float) -> Unit ) -> Unit
```



### Label



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
font_size | float | R/W | 
text | string | R/W | 

#### Methods

##### bind

```rust
label.bind ( boundValue : Cell<T>,
             format : string ) -> ksp::ui::Label
```



### Line2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
closed | bool | R/W | 
points | [ksp::math::Vec2](/reference/ksp/math.md#vec2)[] | R/W | 
stroke_color | [ksp::console::RgbaColor](/reference/ksp/console.md#rgbacolor) | R/W | 
thickness | float | R/W | 

### PixelLine2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
closed | bool | R/W | 
points | [ksp::math::Vec2](/reference/ksp/math.md#vec2)[] | R/W | 
stroke_color | [ksp::console::RgbaColor](/reference/ksp/console.md#rgbacolor) | R/W | 

### Polygon2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
fill_color | [ksp::console::RgbaColor](/reference/ksp/console.md#rgbacolor) | R/W | 
points | [ksp::math::Vec2](/reference/ksp/math.md#vec2)[] | R/W | 

### Rect2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
fill_color | [ksp::console::RgbaColor](/reference/ksp/console.md#rgbacolor) | R/W | 
point1 | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
point2 | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 

### Rotate2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
degrees | float | R/W | 
pivot | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 

#### Methods

##### add_line

```rust
rotate2d.add_line ( points : ksp::math::Vec2[],
                    strokeColor : ksp::console::RgbaColor,
                    closed : bool,
                    thickness : float ) -> ksp::ui::Line2D
```



##### add_pixel_line

```rust
rotate2d.add_pixel_line ( points : ksp::math::Vec2[],
                          strokeColor : ksp::console::RgbaColor,
                          closed : bool ) -> ksp::ui::PixelLine2D
```



##### add_polygon

```rust
rotate2d.add_polygon ( points : ksp::math::Vec2[],
                       fillColor : ksp::console::RgbaColor ) -> ksp::ui::Polygon2D
```



##### add_rect

```rust
rotate2d.add_rect ( point1 : ksp::math::Vec2,
                    point2 : ksp::math::Vec2,
                    fillColor : ksp::console::RgbaColor ) -> ksp::ui::Rect2D
```



##### add_rotate

```rust
rotate2d.add_rotate ( degrees : float ) -> ksp::ui::Rotate2D
```



##### add_scale

```rust
rotate2d.add_scale ( scale : ksp::math::Vec2 ) -> ksp::ui::Scale2D
```



##### add_text

```rust
rotate2d.add_text ( position : ksp::math::Vec2,
                    text : string,
                    fontSize : float,
                    color : ksp::console::RgbaColor,
                    degrees : float,
                    pivot : ksp::math::Vec2 ) -> ksp::ui::Text2D
```



##### add_translate

```rust
rotate2d.add_translate ( translate : ksp::math::Vec2 ) -> ksp::ui::Translate2D
```



##### add_value_raster

```rust
rotate2d.add_value_raster ( point1 : ksp::math::Vec2,
                            point2 : ksp::math::Vec2,
                            values : float[],
                            width : int,
                            height : int,
                            gradientWrapper : ksp::ui::Gradient ) -> ksp::ui::ValueRaster2D
```



##### clear

```rust
rotate2d.clear ( ) -> Unit
```



### Scale2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
pivot | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
scale | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 

#### Methods

##### add_line

```rust
scale2d.add_line ( points : ksp::math::Vec2[],
                   strokeColor : ksp::console::RgbaColor,
                   closed : bool,
                   thickness : float ) -> ksp::ui::Line2D
```



##### add_pixel_line

```rust
scale2d.add_pixel_line ( points : ksp::math::Vec2[],
                         strokeColor : ksp::console::RgbaColor,
                         closed : bool ) -> ksp::ui::PixelLine2D
```



##### add_polygon

```rust
scale2d.add_polygon ( points : ksp::math::Vec2[],
                      fillColor : ksp::console::RgbaColor ) -> ksp::ui::Polygon2D
```



##### add_rect

```rust
scale2d.add_rect ( point1 : ksp::math::Vec2,
                   point2 : ksp::math::Vec2,
                   fillColor : ksp::console::RgbaColor ) -> ksp::ui::Rect2D
```



##### add_rotate

```rust
scale2d.add_rotate ( degrees : float ) -> ksp::ui::Rotate2D
```



##### add_scale

```rust
scale2d.add_scale ( scale : ksp::math::Vec2 ) -> ksp::ui::Scale2D
```



##### add_text

```rust
scale2d.add_text ( position : ksp::math::Vec2,
                   text : string,
                   fontSize : float,
                   color : ksp::console::RgbaColor,
                   degrees : float,
                   pivot : ksp::math::Vec2 ) -> ksp::ui::Text2D
```



##### add_translate

```rust
scale2d.add_translate ( translate : ksp::math::Vec2 ) -> ksp::ui::Translate2D
```



##### add_value_raster

```rust
scale2d.add_value_raster ( point1 : ksp::math::Vec2,
                           point2 : ksp::math::Vec2,
                           values : float[],
                           width : int,
                           height : int,
                           gradientWrapper : ksp::ui::Gradient ) -> ksp::ui::ValueRaster2D
```



##### clear

```rust
scale2d.clear ( ) -> Unit
```



### Slider



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
value | float | R/W | 

#### Methods

##### bind

```rust
slider.bind ( boundValue : Cell<T> ) -> ksp::ui::Slider
```



##### on_change

```rust
slider.on_change ( onChange : sync fn(float) -> Unit ) -> Unit
```



### StringInputField



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
font_size | float | R/W | 
value | string | R/W | 

#### Methods

##### bind

```rust
stringinputfield.bind ( boundValue : Cell<T> ) -> ksp::ui::StringInputField
```



##### on_change

```rust
stringinputfield.on_change ( onChange : sync fn(string) -> Unit ) -> Unit
```



### Text2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
color | [ksp::console::RgbaColor](/reference/ksp/console.md#rgbacolor) | R/W | 
degrees | float | R/W | 
font_size | float | R/W | 
pivot | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
position | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
text | string | R/W | 

### Toggle



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
enabled | bool | R/W | 
font_size | float | R/W | 
label | string | R/W | 
value | bool | R/W | 

#### Methods

##### bind

```rust
toggle.bind ( boundValue : Cell<T> ) -> ksp::ui::Toggle
```



##### on_change

```rust
toggle.on_change ( onChange : sync fn(bool) -> Unit ) -> Unit
```



### Translate2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
translate | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 

#### Methods

##### add_line

```rust
translate2d.add_line ( points : ksp::math::Vec2[],
                       strokeColor : ksp::console::RgbaColor,
                       closed : bool,
                       thickness : float ) -> ksp::ui::Line2D
```



##### add_pixel_line

```rust
translate2d.add_pixel_line ( points : ksp::math::Vec2[],
                             strokeColor : ksp::console::RgbaColor,
                             closed : bool ) -> ksp::ui::PixelLine2D
```



##### add_polygon

```rust
translate2d.add_polygon ( points : ksp::math::Vec2[],
                          fillColor : ksp::console::RgbaColor ) -> ksp::ui::Polygon2D
```



##### add_rect

```rust
translate2d.add_rect ( point1 : ksp::math::Vec2,
                       point2 : ksp::math::Vec2,
                       fillColor : ksp::console::RgbaColor ) -> ksp::ui::Rect2D
```



##### add_rotate

```rust
translate2d.add_rotate ( degrees : float ) -> ksp::ui::Rotate2D
```



##### add_scale

```rust
translate2d.add_scale ( scale : ksp::math::Vec2 ) -> ksp::ui::Scale2D
```



##### add_text

```rust
translate2d.add_text ( position : ksp::math::Vec2,
                       text : string,
                       fontSize : float,
                       color : ksp::console::RgbaColor,
                       degrees : float,
                       pivot : ksp::math::Vec2 ) -> ksp::ui::Text2D
```



##### add_translate

```rust
translate2d.add_translate ( translate : ksp::math::Vec2 ) -> ksp::ui::Translate2D
```



##### add_value_raster

```rust
translate2d.add_value_raster ( point1 : ksp::math::Vec2,
                               point2 : ksp::math::Vec2,
                               values : float[],
                               width : int,
                               height : int,
                               gradientWrapper : ksp::ui::Gradient ) -> ksp::ui::ValueRaster2D
```



##### clear

```rust
translate2d.clear ( ) -> Unit
```



### ValueRaster2D



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
gradient | [ksp::ui::Gradient](/reference/ksp/ui.md#gradient) | R/W | 
point1 | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
point2 | [ksp::math::Vec2](/reference/ksp/math.md#vec2) | R/W | 
raster_height | int | R/O | 
raster_width | int | R/O | 
values | float[] | R/W | 

### Window



#### Fields

Name | Type | Read-only | Description
--- | --- | --- | ---
is_closed | bool | R/O | 

#### Methods

##### add_button

```rust
window.add_button ( label : string,
                    align : ksp::up::Align,
                    stretch : float ) -> ksp::ui::Button
```



##### add_canvas

```rust
window.add_canvas ( minWidth : float,
                    minHeight : float,
                    align : ksp::up::Align,
                    stretch : float ) -> ksp::ui::Canvas
```



##### add_float_input

```rust
window.add_float_input ( align : ksp::up::Align,
                         stretch : float ) -> ksp::ui::FloatInputField
```



##### add_horizontal

```rust
window.add_horizontal ( gap : float,
                        align : ksp::up::Align,
                        stretch : float ) -> ksp::ui::Container
```



##### add_horizontal_panel

```rust
window.add_horizontal_panel ( gap : float,
                              align : ksp::up::Align,
                              stretch : float ) -> ksp::ui::Container
```



##### add_horizontal_slider

```rust
window.add_horizontal_slider ( min : float,
                               max : float,
                               align : ksp::up::Align,
                               stretch : float ) -> ksp::ui::Slider
```



##### add_int_input

```rust
window.add_int_input ( align : ksp::up::Align,
                       stretch : float ) -> ksp::ui::IntInputField
```



##### add_label

```rust
window.add_label ( label : string,
                   align : ksp::up::Align,
                   stretch : float ) -> ksp::ui::Label
```



##### add_string_input

```rust
window.add_string_input ( align : ksp::up::Align,
                          stretch : float ) -> ksp::ui::StringInputField
```



##### add_toggle

```rust
window.add_toggle ( label : string,
                    align : ksp::up::Align,
                    stretch : float ) -> ksp::ui::Toggle
```



##### add_vertical

```rust
window.add_vertical ( gap : float,
                      align : ksp::up::Align,
                      stretch : float ) -> ksp::ui::Container
```



##### add_vertical_panel

```rust
window.add_vertical_panel ( gap : float,
                            align : ksp::up::Align,
                            stretch : float ) -> ksp::ui::Container
```



##### close

```rust
window.close ( ) -> Unit
```



## Constants

Name | Type | Description
--- | --- | ---
Align | ksp::up::AlignConstants | Alignment of the element in off direction (horizontal for vertical container and vice versa)


## Functions


### gradient

```rust
pub sync fn gradient ( start : ksp::console::RgbaColor,
                       end : ksp::console::RgbaColor ) -> ksp::ui::Gradient
```



### open_centered_window

```rust
pub sync fn open_centered_window ( title : string,
                                   width : float,
                                   height : float ) -> ksp::ui::Window
```



### open_window

```rust
pub sync fn open_window ( title : string,
                          x : float,
                          y : float,
                          width : float,
                          height : float ) -> ksp::ui::Window
```



### screen_size

```rust
pub sync fn screen_size ( ) -> ksp::math::Vec2
```


